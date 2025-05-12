using DesafioValide.Domain.Entities;
using DesafioValide.Domain.Util;

namespace DesafioValide.Domain.Interfaces
{
    public interface IRepository<TEntidade> where TEntidade : Entidade
    {
        void Deletar(int id);
        List<TEntidade> ObterTodos();
        PaginationData<TEntidade> ObterTodosPaginado(int pagina, int limite);
        TEntidade ObterPorId(int id);
        void Inserir(TEntidade entidade);
        void Atualizar(int id, TEntidade entidade);
    }
}