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

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<MovimentoViewModel>>> Get([FromBody] FilterMovimViewModel filters)
        {
            var filter = _mapper.Map<FilterMovim>(filters);

            var movim = _mapper.Map<IEnumerable<MovimentoViewModel>>(await _movimentoService.GetMovimentoWithItem(filter));

            return CustomResponse(movim);
        }
    }
}
