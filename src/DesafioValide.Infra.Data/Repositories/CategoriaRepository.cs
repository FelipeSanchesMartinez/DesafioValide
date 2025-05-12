using DesafioValide.Domain.Entities;
using DesafioValide.Domain.Interfaces;

namespace DesafioValide.Infra.Data.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(SQLContext sqlContext) : base(sqlContext)
        {
        }
    }
}
