using DesafioValide.Application.Requests.Produtos;
using FluentValidation;

namespace DesafioValide.Application.Validations.Produtos
{
    public abstract class ProdutoValidation<T> : AbstractValidator<T> where T : ProdutoRequest
    {
        protected ProdutoValidation()
        {
            RuleFor(x => x.Nome)
             .NotEmpty()
             .MaximumLength(100);

            RuleFor(x => x.Preco)
              .NotEmpty();

            RuleFor(x => x.Estoque)
              .NotEmpty();

            RuleFor(x => x.CategoriaId)
              .NotEmpty();

        }
    }
}
