using DesafioValide.Application.Queries.Produtos;
using DesafioValide.Application.Requests.Entities;
using DesafioValide.Application.Requests.Produtos;
using DesafioValide.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioValide.Services.Api.Controllers
{
    [ApiController]
    [Route("/api/produto")]

    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosPaginado(int pagina, int limite)
        {
            return Ok(ApiResult.SuccessResult(await _mediator.Send(new ObterTodosProdutoPaginadoRequest(pagina,limite))));
        }

        [HttpGet("nome/{produtoNome}")]
        public async Task<IActionResult> ObterProdutoPorNomePaginado(int pagina, int limite, string produtoNome)
        {
            return Ok(ApiResult.SuccessResult(await _mediator.Send(new ObterProdutoPorNomePaginadoRequest(pagina, limite, produtoNome))));
        }
        [HttpGet("categoria/{categoriaId}")]
        public async Task<IActionResult> ObterProdutoPorCategoriaIdPaginado(int pagina, int limite, int categoriaId)
        {
            return Ok(ApiResult.SuccessResult(await _mediator.Send(new ObterProdutoPorCategoriaIdPaginadoRequest(pagina, limite, categoriaId))));
        }
        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] InserirProdutoResquest request)
        {
            await _mediator.Send(request);
            return Ok(ApiResult.SuccessResult());
        }
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarProdutoRequest request)
        {
            await _mediator.Send(request);
            return Ok(ApiResult.SuccessResult());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            await _mediator.Send(new DeleteEntityByIdRequest<ProdutoRequest>(id));
            return Ok(ApiResult.SuccessResult());
        }
    }
}
