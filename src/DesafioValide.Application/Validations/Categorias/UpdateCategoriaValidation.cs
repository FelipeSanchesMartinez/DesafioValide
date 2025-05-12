using DesafioValide.Application.Requests.Categorias;
using FluentValidation;

namespace DesafioValide.Application.Validations.Categorias
{
    public class UpdateCategoriaValidation : CategoriaValidation<AtualizarCategoriaRequest>
    {
        public UpdateCategoriaValidation() : base()
        {
            IdValidation();
        }

        protected void IdValidation() =>
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
    }
}
