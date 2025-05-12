namespace DesafioValide.Domain.Entities
{
    public class Produto :Entidade
    {
        public required string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public int CategoriaId { get; set; }
        public required Categoria Categoria { get; set; }
    }
}
