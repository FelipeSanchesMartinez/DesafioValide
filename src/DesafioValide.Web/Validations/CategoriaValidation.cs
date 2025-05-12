using DesafioValide.Application.ViewModel;
using FluentValidation;

namespace DesafioValide.Web.Validations
{
    public class CategoriaValidation : AbstractValidator<CategoriaViewModel>
    {
        public CategoriaValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
