using API.ViewModel;
using AutoMapper;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ClientesProdutosController : BaseController
    {
        private readonly IClienteProdutoService _clienteProdutoService;
        private readonly IMapper _mapper;

        public ClientesProdutosController(IClienteProdutoService clienteProdutoService,
                                        IMapper mapper,
                                        INotificator notificator): base(notificator)
        {
            _clienteProdutoService = clienteProdutoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteProdutoViewModel>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<ClienteProdutoViewModel>>(await _clienteProdutoService.GetAllWithInclude()));
        }

        [HttpPost()]
        public async Task<ActionResult<ClienteProdutoViewModel>> Post(ClienteProdutoViewModel clientProdViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            clientProdViewModel.Id =  await _clienteProdutoService.Create(_mapper.Map<ClienteProduto>(clientProdViewModel));
            return CustomResponse(clientProdViewModel);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<ClienteProdutoViewModel>> Put(long id, [FromBody] ClienteProdutoViewModel clientProdViewModel)
        {
            if (id != clientProdViewModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _clienteProdutoService.Update(_mapper.Map<ClienteProduto>(clientProdViewModel));
            return CustomResponse(clientProdViewModel);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ClienteProdutoViewModel>> Delete(long id)
        {
            var clientProd = await _clienteProdutoService.SearchId(id);

            if (clientProd == null)
                return NotFound();

            await _clienteProdutoService.Delete(id);
            return CustomResponse();
        }
    }
}
