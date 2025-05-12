using DesafioValide.Infra.Http.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesafioValide.Infra.Http
{
    public class CategoriatHttpClient : HttpClientCrudService, ICategoriatHttpClient
    {
        public CategoriatHttpClient(ILogger<HttpClientService> logger, IHttpClientFactory httpClientFactory) : base("categoria", logger, httpClientFactory)
        {
        }
    }
}
