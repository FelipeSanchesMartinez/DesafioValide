using System.Net.Http.Json;
using System.Text.Json;
using DesafioValide.Infra.Http.Model;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DesafioValide.Infra.Http
{
    public class HttpClientService
    {
        private readonly ILogger<HttpClientService> _logger;
        protected HttpClient Client { get; }
        public HttpClientService(ILogger<HttpClientService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            Client = httpClientFactory.CreateClient("api");
        }

        public async ValueTask<TResponse?> SendRequest<TResponse>(string requestUri, HttpMethod method, object? data = null, bool autoLoading = true)
        {
            try
            {
                var message = new HttpRequestMessage(method, requestUri);
                if (data is not null)
                    message.Content = new StringContent(JsonSerializer.Serialize(data), System.Text.Encoding.UTF8, "application/json");

                if (autoLoading == false)
                    message.Headers.Add("not-auto-loading", autoLoading.ToString());

                var res = await Client.SendAsync(message);
                var payload = await res.Content.ReadFromJsonAsync<ApiResponse<TResponse?>>();
                return payload!.Data;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return default;
            }
        }

        public async ValueTask<bool> SendRequest(string requestUri, HttpMethod method, object? data = null, bool autoLoading = true)
        {
            try
            {
                var message = new HttpRequestMessage(method, requestUri);
                if (data is not null)
                    message.Content = new StringContent(JsonSerializer.Serialize(data), System.Text.Encoding.UTF8, "application/json");

                if (autoLoading == false)
                    message.Headers.Add("not-auto-loading", autoLoading.ToString());

                var res = await Client.SendAsync(message);
                return res.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return false;
            }
        }
    }
}
