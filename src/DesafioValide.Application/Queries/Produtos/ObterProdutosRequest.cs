using DesafioValide.Application.ViewModel;
using DesafioValide.Domain.Util;
using MediatR;

namespace DesafioValide.Application.Queries.Produtos
{
    public abstract class ObterProdutosRequest : IRequest<PaginationData<ProdutoViewModel>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }

    }
}
