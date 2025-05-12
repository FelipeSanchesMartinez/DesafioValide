using DesafioValide.Application.Extensions;
using DesafioValide.Application.Pipelines;
using DesafioValide.Application.Requests.Produtos;
using DesafioValide.Infra.Data;
using DesafioValide.Infra.Data.Extensions;
using DesafioValide.Services.Api.Middlewares;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SQLContext>();

builder.Services.AddCors(opt => opt.AddPolicy("*", pol => pol.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().Build()));

builder.Services.AddInfraData();

builder.Services.AddApplication();

builder.Services.AddValidatorsFromAssembly(typeof(InserirProdutoResquest).Assembly);

builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssembly(typeof(InserirProdutoResquest).Assembly);
    opt.AddOpenBehavior(typeof(ValidationBehavior<,>));

});
builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("*");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
