using DesafioValide.Application.ViewModel;
using DesafioValide.Domain.Util;
using DesafioValide.Infra.Http.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesafioValide.Infra.Http
{
    public class ProdutoHttpClient : HttpClientCrudService, IProdutoHttpClient
    {
        public ProdutoHttpClient(ILogger<HttpClientService> logger, IHttpClientFactory httpClientFactory) : base("produto", logger, httpClientFactory)
        {

        }

        public ValueTask<PaginationData<ProdutoViewModel>?> OterProdutoPorCategoriaId(long categoriaId,
                                                                                    int pagina,
                                                                                    int limite)
        {
            return SendRequest<PaginationData<ProdutoViewModel>>($"{Route}/categoria/{categoriaId}?pagina={pagina}&limite={limite}", HttpMethod.Get);
        }
        public ValueTask<PaginationData<ProdutoViewModel>?> ProcurarProdutoPorNome(string produtoNome,
                                                                                int pagina,
                                                                                int limite)
        {
            return SendRequest<PaginationData<ProdutoViewModel>>($"{Route}/nome/{produtoNome}?pagina={pagina}&limite={limite}", HttpMethod.Get);
        }
    }
}
