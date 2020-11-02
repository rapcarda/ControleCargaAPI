using API.ViewModel;
using API.ViewModel.Util;
using AutoMapper;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ClientesController : BaseController
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClientesController(IClienteService clienteService,
                                 IMapper mapper,
                                 INotificator notificator): base(notificator)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteService.GetAll()));
        }

        [HttpPost()]
        public async Task<ActionResult<ClienteViewModel>> Post(ClienteViewModel clientViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            clientViewModel.Id = await _clienteService.Create(_mapper.Map<Cliente>(clientViewModel));
            return CustomResponse(clientViewModel);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<ClienteViewModel>> Put(long id, [FromBody] ClienteViewModel clientViewModel)
        {
            if (id != clientViewModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _clienteService.Update(_mapper.Map<Cliente>(clientViewModel));
            return CustomResponse(clientViewModel);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ClienteViewModel>> Delete(long id)
        {
            var client = await _clienteService.SearchId(id);

            if (client == null)
                return NotFound();

            await _clienteService.Delete(id);
            return CustomResponse();
        }

        [HttpGet("GetClienteCombo")]
        public async Task<IEnumerable<ResponseComboViewModel>> GetCombo()
        {
            var result = await _clienteService.GetAll();
            return result.Select(x => new ResponseComboViewModel { CodigoInt = x.Codigo, Descricao = x.Descricao, Id = x.Id });
        }
    }
}
