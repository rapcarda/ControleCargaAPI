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
    public class FrotasController : BaseController
    {
        private readonly IFrotaService _frotaService;
        private readonly IMapper _mapper;

        public FrotasController(IFrotaService frotaService,
                                IMapper mapper,
                                INotificator notificator): base(notificator)
        {
            _frotaService = frotaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrotaViewModel>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<FrotaViewModel>>(await _frotaService.GetAll()));
        }

        [HttpPost()]
        public async Task<ActionResult<FrotaViewModel>> Post(FrotaViewModel frotaViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            frotaViewModel.Id = await _frotaService.Create(_mapper.Map<Frota>(frotaViewModel));
            return CustomResponse(frotaViewModel);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<FrotaViewModel>> Put(long id, [FromBody] FrotaViewModel frotaViewModel)
        {
            if (id != frotaViewModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _frotaService.Update(_mapper.Map<Frota>(frotaViewModel));
            return CustomResponse(frotaViewModel);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<FrotaViewModel>> Delete(long id)
        {
            var frota = await _frotaService.SearchId(id);

            if (frota == null)
                return NotFound();

            await _frotaService.Delete(id);
            return CustomResponse();
        }
    }
}
