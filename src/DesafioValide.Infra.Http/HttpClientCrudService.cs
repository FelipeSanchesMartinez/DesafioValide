using DesafioValide.Domain.Util;
using DesafioValide.Infra.Http.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesafioValide.Infra.Http
{
    public class HttpClientCrudService : HttpClientService, IHttpClientCrudService
    {
        protected string Route { get; }
        public HttpClientCrudService(string route, ILogger<HttpClientService> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
            Route = route;
        }
        public ValueTask<PaginationData<T>?> ObterTodosPaginado<T>(int pagina, int limite)
        {
            return SendRequest<PaginationData<T>>($"{Route}?pagina={pagina}&limite={limite}", HttpMethod.Get);
        }
        public ValueTask<List<T>?> ObterTodos<T>()
        {
            return SendRequest<List<T>>($"{Route}/todos", HttpMethod.Get);
        }
        public ValueTask<bool> Inserir<T>(T item)
        {
            return SendRequest($"{Route}", HttpMethod.Post, item);
        }

        public ValueTask<bool> Atualizar<T>(T item)
        {
            return SendRequest($"{Route}", HttpMethod.Put, item);
        }

        public ValueTask<bool> Deletar(int id)
        {
            return SendRequest($"{Route}/{id}", HttpMethod.Delete);
        }
    }
}
