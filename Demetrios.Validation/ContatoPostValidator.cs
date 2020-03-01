using System;
using FluentValidation;
using FluentValidation.Results;
using Demetrios.Models;

namespace Demetrios.Validation
{
    public class ContatoPostValidator : AbstractValidator<ContatoPost>
    {
        public ContatoPostValidator()
        {
            RuleFor(m => m.Nome).NotNull().WithMessage("Nome que descreva o contato.");

            RuleFor(m => m.Canal).NotNull().WithMessage("Tipo de canal de contato, podendo ser email, celular ou fixo.");

            RuleFor(m => m.Valor).NotNull().WithMessage("Valor para o canal de contato.");

            RuleFor(m => m.Obs).NotNull().WithMessage("Qualquer observação que seja pertinente.");
        }

        protected override bool PreValidate(ValidationContext<ContatoPost> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Por favor submeta um modelo diferente de nulo."));

                return false;
            }
            return true;
        }
    }
}
