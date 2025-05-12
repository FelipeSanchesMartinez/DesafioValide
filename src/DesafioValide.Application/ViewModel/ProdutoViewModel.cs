namespace DesafioValide.Application.ViewModel
{
    public class ProdutoViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string CategoriaNome { get; set; }
        public long CategoriaId { get; set; }
    }
}

