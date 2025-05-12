namespace DesafioValide.Application.Queries.Produtos
{
    public class ObterProdutoPorCategoriaIdPaginadoRequest:ObterProdutosRequest
    {
        public int CategoriaId { get; set; }
        public ObterProdutoPorCategoriaIdPaginadoRequest(int page, int limit, int categoriaId)
        {
            Page = page;
            Limit = limit;
            CategoriaId = categoriaId;
        }
    }
}
