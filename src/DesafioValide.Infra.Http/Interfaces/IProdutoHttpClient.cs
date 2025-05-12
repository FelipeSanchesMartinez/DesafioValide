using DesafioValide.Application.ViewModel;
using DesafioValide.Domain.Util;

namespace DesafioValide.Infra.Http.Interfaces
{
    public interface IProdutoHttpClient : IHttpClientCrudService
    {
        ValueTask<PaginationData<ProdutoViewModel>?> OterProdutoPorCategoriaId(long categoriaId, int pagina, int limite);
        ValueTask<PaginationData<ProdutoViewModel>?> ProcurarProdutoPorNome(string produtoNome, int pagina, int limite);
    }
}