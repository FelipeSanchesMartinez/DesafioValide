using DesafioValide.Domain.Util;

namespace DesafioValide.Infra.Http.Interfaces
{
    public interface IHttpClientCrudService
    {
        ValueTask<bool> Deletar(int id);
        ValueTask<List<T>> ObterTodos<T>();
        ValueTask<PaginationData<T>?> ObterTodosPaginado<T>(int pagina, int limite);
        ValueTask<bool> Inserir<T>(T item);
        ValueTask<bool> Atualizar<T>(T item);

    }
}