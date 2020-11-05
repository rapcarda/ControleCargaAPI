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
    public class ColetoresController : BaseController
    {
        private readonly IColetorService _coletorService;
        private readonly IMapper _mapper;

        public ColetoresController(IColetorService coletorService,
                                   IMapper mapper,
                                   INotificator notificator): base(notificator)
        {
            _coletorService = coletorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColetorViewModel>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<ColetorViewModel>>(await _coletorService.GetAll()));
        }

        [HttpPost()]
        public async Task<ActionResult<ColetorViewModel>> Post(ColetorViewModel coletorViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            coletorViewModel.Id = await _coletorService.Create(_mapper.Map<Coletor>(coletorViewModel));
            return CustomResponse(coletorViewModel);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<ColetorViewModel>> Put(long id, [FromBody] ColetorViewModel coletorViewModel)
        {
            if (id != coletorViewModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _coletorService.Update(_mapper.Map<Coletor>(coletorViewModel));
            return CustomResponse(coletorViewModel);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ColetorViewModel>> Delete(long id)
        {
            var coletor = await _coletorService.SearchId(id);

            if (coletor == null)
                return NotFound();

            await _coletorService.Delete(id);
            return CustomResponse();
        }
    }
}
