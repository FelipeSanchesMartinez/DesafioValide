using DesafioValide.Application.Queries.Categorias;
using DesafioValide.Application.Requests.Categorias;
using DesafioValide.Application.Requests.Entities;
using DesafioValide.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioValide.Services.Api.Controllers
{
    [ApiController]
    [Route("/api/categoria")]

    public class CategoriaController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosPaginado(int pagina, int limite)
        {
            return Ok(ApiResult.SuccessResult(await _mediator.Send(new ObterCategoriaPaginedRequest(pagina, limite))));
        }
        [HttpGet("todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(ApiResult.SuccessResult(await _mediator.Send(new ObterTodasCategoriaRequest())));
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] InserirCategoriaRequest request)
        {
            await _mediator.Send(request);
            return Ok(ApiResult.SuccessResult());
        }
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarCategoriaRequest request)
        {
            await _mediator.Send(request);
            return Ok(ApiResult.SuccessResult());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            await _mediator.Send(new DeleteEntityByIdRequest<CategoriaRequest>(id));
            return Ok(ApiResult.SuccessResult());
        }
    }
}
