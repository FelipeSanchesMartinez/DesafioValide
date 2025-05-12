using MediatR;

namespace DesafioValide.Application.Requests.Produtos
{
    public abstract class ProdutoRequest :IRequest
    {
        public required string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public long CategoriaId { get; set; }
    }
}
