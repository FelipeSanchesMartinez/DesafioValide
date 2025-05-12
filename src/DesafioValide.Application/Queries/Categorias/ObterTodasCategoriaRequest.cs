using DesafioValide.Application.ViewModel;
using MediatR;

namespace DesafioValide.Application.Queries.Categorias
{
    public class ObterTodasCategoriaRequest :IRequest<List<CategoriaViewModel>>
    {
    }
}
