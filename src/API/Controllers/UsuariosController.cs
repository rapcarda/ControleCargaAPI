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
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioService usuarioService,
                                 IMapper mapper,
                                 INotificator notificator): base(notificator)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioService.GetAll()));
        }

        [HttpPost()]
        public async Task<ActionResult<UsuarioViewModel>> Post(UsuarioViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            userViewModel.Id = await _usuarioService.Create(_mapper.Map<Usuario>(userViewModel));
            return CustomResponse(userViewModel);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<UsuarioViewModel>> Put(long id, [FromBody] UsuarioViewModel userViewModel)
        {
            if (id != userViewModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _usuarioService.Update(_mapper.Map<Usuario>(userViewModel));
            return CustomResponse(userViewModel);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<UsuarioViewModel>> Delete(long id)
        {
            var user = await _usuarioService.SearchId(id);

            if (user == null)
                return NotFound();

            await _usuarioService.Delete(id);
            return CustomResponse();
        }
    }
}
