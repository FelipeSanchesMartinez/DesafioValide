using DesafioValide.Application.ViewModel;
using DesafioValide.Domain.Util;
using MediatR;

namespace DesafioValide.Application.Queries.Categorias
{
    public abstract class ObterCategoiaRequest : IRequest<PaginationData<CategoriaViewModel>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }

    }
}
