namespace DesafioValide.Application.Queries.Categorias
{
    public class ObterCategoriaPaginedRequest : ObterCategoiaRequest
    {
    
        public ObterCategoriaPaginedRequest(int page, int limit)
        {
            Page = page;
            Limit = limit;
        }
    }
}
