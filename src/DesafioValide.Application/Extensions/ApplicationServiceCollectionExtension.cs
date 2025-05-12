using Microsoft.Extensions.DependencyInjection;
using DesafioValide.Application.MapperProfiles;

namespace DesafioValide.Application.Extensions
{
    public static class ApplicationServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(RequestAndModelToEntityProfile).Assembly);
        }
    }
}
