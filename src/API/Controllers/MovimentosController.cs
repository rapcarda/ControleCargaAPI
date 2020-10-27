using API.ViewModel;
using AutoMapper;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class MovimentosController : BaseController
    {
        private readonly IMovimentoService _movimentoService;
        private readonly IMapper _mapper;

        public MovimentosController(IMovimentoService movimentoService,
                                    IMapper mapper,
                                    INotificator notificator): base(notificator)
        {
            _movimentoService = movimentoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimentoViewModel>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<MovimentoViewModel>>(await _movimentoService.GetMovimentoWithItem()));
        }
    }
}
