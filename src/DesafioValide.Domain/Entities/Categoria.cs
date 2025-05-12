namespace DesafioValide.Domain.Entities
{
    public class Categoria :Entidade
    {
        public required string Nome { get; set; }
        public List<Produto>? Produtos { get; set; } 
    }
}
