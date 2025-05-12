using AutoMapper;
using DesafioValide.Application.ViewModel;
using DesafioValide.Web.ViewModels;

namespace DesafioValide.Web.Util.MapperProfiles
{
    public class ModelToModelProfile : Profile
    {
        public ModelToModelProfile()
        {
            CreateMap<CategoriaViewModel, CategoriaViewModel>().ReverseMap();
            CreateMap<ProdutoViewModel, ProdutoViewModel>().ReverseMap();
        }
    }
}
