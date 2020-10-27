using API.ViewModel;
using AutoMapper;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoService produtoService,
                                 IMapper mapper,
                                 INotificator notificator) : base(notificator)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.GetAll()));
        }

        [HttpPost()]
        public async Task<ActionResult<ProdutoViewModel>> Post(ProdutoViewModel prodViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            prodViewModel.Id = await _produtoService.Create(_mapper.Map<Produto>(prodViewModel));
            return CustomResponse(prodViewModel);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<ProdutoViewModel>> Put(long id, [FromBody] ProdutoViewModel prodViewModel)
        {
            if (id != prodViewModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _produtoService.Update(_mapper.Map<Produto>(prodViewModel));
            return CustomResponse(prodViewModel);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ProdutoViewModel>> Delete(long id)
        {
            var prod = await _produtoService.SearchId(id);

            if (prod == null)
                return NotFound();

            await _produtoService.Delete(id);
            return CustomResponse();
        }
    }
}
