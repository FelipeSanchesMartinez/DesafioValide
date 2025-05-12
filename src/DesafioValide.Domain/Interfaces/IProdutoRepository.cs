using DesafioValide.Domain.Entities;
using DesafioValide.Domain.Util;

namespace DesafioValide.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        PaginationData<Produto> ObterPorProdutoPorCategoriaIdPaginado(int pagina, int limite, int categoryId);
        PaginationData<Produto> ObterPorProdutoNomePaginado(int pagina, int limite, string produtoNome);
    }
}