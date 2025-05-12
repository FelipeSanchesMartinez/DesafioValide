using DesafioValide.Application.Requests.Produtos;
using FluentValidation;

namespace DesafioValide.Application.Validations.Produtos
{
    public class UpdateProdutoValidation : ProdutoValidation<AtualizarProdutoRequest>
    {
        public UpdateProdutoValidation() : base()
        {
            IdValidation();
        }

        protected void IdValidation() =>
         RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
    }
}
