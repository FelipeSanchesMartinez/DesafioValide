using DesafioValide.Application.Requests.Categorias;
using FluentValidation;

namespace DesafioValide.Application.Validations.Categorias
{
    public abstract class CategoriaValidation<T> : AbstractValidator<T> where T : CategoriaRequest
    {
        protected CategoriaValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
