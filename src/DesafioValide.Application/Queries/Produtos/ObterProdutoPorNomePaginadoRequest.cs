namespace DesafioValide.Application.Queries.Produtos
{
    public class ObterProdutoPorNomePaginadoRequest:ObterProdutosRequest
    {
        public string Name { get; set; }

        public ObterProdutoPorNomePaginadoRequest(int page, int limit,string name)
        {
            Page = page;
            Limit = limit;
            Name = name;
        }
    }
}
