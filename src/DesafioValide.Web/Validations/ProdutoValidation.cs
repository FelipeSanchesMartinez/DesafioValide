using DesafioValide.Application.ViewModel;
using DesafioValide.Web.ViewModels;
using FluentValidation;

namespace DesafioValide.Web.Validations
{
    public class ProdutoValidation: AbstractValidator<ProdutoViewModel>
    {
        public ProdutoValidation()
        {
            RuleFor(x => x.Nome)
              .NotEmpty()
              .MaximumLength(100);

            RuleFor(x => x.Preco)
              .NotEmpty()
              .WithMessage("Nescessario definir um preço para esta produto");

            RuleFor(x => x.Estoque)
              .NotEmpty()
              .WithMessage("Nescessario definir a quantidade em estoque para esta produto");

            RuleFor(x => x.CategoriaId)
              .NotEmpty()
              .WithMessage("Nescessario escolher alguma categoria para esta produto");
        }
    }
}
