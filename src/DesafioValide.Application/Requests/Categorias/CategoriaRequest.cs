using MediatR;

namespace DesafioValide.Application.Requests.Categorias
{
    public abstract class CategoriaRequest :IRequest
    {
        public required string Nome { get; set; }
    }
}
