using Blazored.Toast.Services;
using DesafioValide.Web.States;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text;
using DesafioValide.Web.ViewModels;


namespace DesafioValide.Web.HttpHandler
{
    public class HttpInterceptorHandler(LoadingFullscreenState fullscreenLoadingState,
                                         IToastService toastService,
                                         NavigationManager navigationManager) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool notLoading = request.Headers.Where(x => x.Key == "not-auto-loading").Any();

            if (!notLoading)
                fullscreenLoadingState.SetLoading(true);
            try
            {
                var res = await base.SendAsync(request, cancellationToken);

                if (!notLoading)
                    fullscreenLoadingState.SetLoading(false);

                if (!res.IsSuccessStatusCode)
                {
                    try
                    {

                        var content = await res.Content.ReadAsStringAsync();
                        var apiResult = JsonSerializer.Deserialize<ApiResponse<object?>>(content);

                        if (apiResult is null)
                        {
                            toastService.ShowError($"Um erro inesperado ocorreu, status {res.StatusCode}", toast => toast.Timeout = 30);
                            return res;
                        }

                        foreach (var error in apiResult.Errors)
                            toastService.ShowError(error, toast => toast.Timeout = 30);

                        return res;
                    }
                    catch (Exception ex)
                    {
                        toastService.ShowError($"Um erro inesperado ocorreu, status {res.StatusCode}, {ex.Message}", toast => toast.Timeout = 30);
                        return res;
                    }
                }

                return res;
            }
            catch (Exception ex)
            {
                fullscreenLoadingState.SetLoading(false);
                var obj = new ApiResponse<object?>(false, null, [ex.Message]);
                toastService.ShowError($"Um erro inesperado aconteceu, {ex.Message}", toast => toast.Timeout = 10);
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
                return response;
            }
        }
    }
}
