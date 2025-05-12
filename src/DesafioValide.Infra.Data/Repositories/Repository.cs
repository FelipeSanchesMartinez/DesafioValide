using DesafioValide.Domain.Entities;
using DesafioValide.Domain.Interfaces;
using DesafioValide.Domain.Util;
using Microsoft.EntityFrameworkCore;

namespace DesafioValide.Infra.Data.Repositories
{
    public class Repository<TEntidade> :  IRepository<TEntidade> where TEntidade : Entidade
    {
        protected SQLContext SQLContext;
        protected DbSet<TEntidade> DbSet;
        public Repository(SQLContext sqlContext)
        {
            SQLContext = sqlContext ?? throw new ArgumentNullException(nameof(sqlContext));
            DbSet = SQLContext.Set<TEntidade>();
        }
        public virtual List<TEntidade> ObterTodos()
        {
            return DbSet.AsNoTracking().ToList();
        }
        public virtual PaginationData<TEntidade> ObterTodosPaginado(int pagina, int limite)
        {
            var query = DbSet.AsNoTracking();

            var retultadoTotal = query.Count();

            var itens = query.Skip((pagina - 1) * limite)
                             .Take(limite)
                             .ToList();

            return new PaginationData<TEntidade>(itens, pagina, limite, retultadoTotal);

        }

        public virtual TEntidade ObterPorId(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(entidade => entidade.Id == id)!;
        }

        public virtual void Inserir(TEntidade entidade)
        {
            DbSet.Add(entidade);

        }

        public virtual void Atualizar(int id, TEntidade entidade)
        {
            DbSet.Update(entidade);
        }

        public virtual void Deletar(int id)
        {

            TEntidade? entidade = DbSet.AsNoTracking().FirstOrDefault(entidade => entidade.Id == id);
            if (entidade != null)
            {
                DbSet.Remove(entidade);
            }
        }

    }

}
