using AutoMapper;
using DesafioValide.Application.Requests.Categorias;
using DesafioValide.Application.Requests.Produtos;
using DesafioValide.Application.ViewModel;
using DesafioValide.Domain.Entities;

namespace DesafioValide.Application.MapperProfiles
{
    public class RequestAndModelToEntityProfile: Profile
    {
        public RequestAndModelToEntityProfile()
        {
            CreateMap<InserirProdutoResquest, Produto>();
            CreateMap<AtualizarProdutoRequest, Produto>();
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();

            CreateMap<InserirCategoriaRequest, Categoria>();
            CreateMap<AtualizarCategoriaRequest, Categoria>();
            CreateMap<CategoriaViewModel, Categoria>().ReverseMap();
        }
    }
}
