namespace DesafioValide.Application.Queries.Produtos
{
    public class ObterTodosProdutoPaginadoRequest : ObterProdutosRequest
    {
    
        public ObterTodosProdutoPaginadoRequest(int page, int limit)
        {
            Page = page;
            Limit = limit;
        }
    }
}
