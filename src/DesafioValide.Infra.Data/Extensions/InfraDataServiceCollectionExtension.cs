using DesafioValide.Domain.Interfaces;
using DesafioValide.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioValide.Infra.Data.Extensions
{
    public static class InfraDataServiceCollectionExtension
    {
        public static void AddInfraData(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
