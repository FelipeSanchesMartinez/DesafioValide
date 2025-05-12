using Blazored.Toast.Services;
using DesafioValide.Web;
using DesafioValide.Web.HttpHandler;
using DesafioValide.Web.States;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DesafioValide.Web.Services;
using FluentValidation;
using DesafioValide.Web.Util.MapperProfiles;
using DesafioValide.Web.Interfaces;
using DesafioValide.Infra.Http.Interfaces;
using DesafioValide.Infra.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddTransient<HttpInterceptorHandler>();
builder.Services.AddSingleton<IAlertService, AlertService>();
builder.Services.AddSingleton<IToastService, ToastService>();
builder.Services.AddSingleton<LoadingFullscreenState>();

builder.Services.AddSingleton<IHttpClientCrudService, HttpClientCrudService>();
builder.Services.AddSingleton<IProdutoHttpClient, ProdutoHttpClient>();
builder.Services.AddSingleton<ICategoriatHttpClient, CategoriatHttpClient>();

builder.Services.AddAutoMapper(typeof(ModelToModelProfile).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

string? apiUrl = @"https://localhost:7095/api/";

builder.Services.AddHttpClient("api", sp => sp.BaseAddress = new Uri(apiUrl))
                    .AddHttpMessageHandler<HttpInterceptorHandler>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
