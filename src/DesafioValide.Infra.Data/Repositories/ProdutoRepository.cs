using DesafioValide.Domain.Entities;
using DesafioValide.Domain.Interfaces;
using DesafioValide.Domain.Util;
using Microsoft.EntityFrameworkCore;

namespace DesafioValide.Infra.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>,IProdutoRepository
    {
        public ProdutoRepository(SQLContext sqlContext) : base(sqlContext)
        {
        }

        public override PaginationData<Produto> ObterTodosPaginado(int page, int limit)
        {
            var query = DbSet.AsNoTracking().Include(p => p.Categoria);
            var totalRecords = query.Count();

            var itens = query.Skip((page - 1) * limit)
                             .Take(limit)
                             .ToList();
            return new PaginationData<Produto>(itens, page, limit, totalRecords);

        }
        public PaginationData<Produto> ObterPorProdutoNomePaginado(int pagina, int limite,string produtoNome)
        {
            var query = DbSet.AsNoTracking().Include(p => p.Categoria).Where(p => p.Nome.ToLower().Contains(produtoNome.ToLower()));
            var resultadoTotal = query.Count();

            var itens = query.Skip((pagina - 1) * limite)
                             .Take(limite)
                             .ToList();

            return new PaginationData<Produto>(itens, pagina, limite, resultadoTotal);

        }
        public PaginationData<Produto> ObterPorProdutoPorCategoriaIdPaginado(int pagina, int limite, int categoryId)
        {
            var query = DbSet.AsNoTracking().Include(p => p.Categoria).Where(p => p.CategoriaId == categoryId);
            var resultadoTotal = query.Count();

            var itens = query.Skip((pagina - 1) * limite)
                             .Take(limite)
                             .ToList();

            return new PaginationData<Produto>(itens, pagina, limite, resultadoTotal);

        }
    }
}
