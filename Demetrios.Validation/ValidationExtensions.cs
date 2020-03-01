using System.Collections.Generic;
using FluentValidation.Results;
using Demetrios.Models;

namespace Demetrios.Validation
{
    public static class ValidationExtensions
    {
        public static bool IsValid(this ContatoPost contatoPost, out IEnumerable<string> errors)
        {
            var validator = new ContatoPostValidator();

            var validationResult = validator.Validate(contatoPost);

            errors = AggregateErrors(validationResult);

            return validationResult.IsValid;
        }

        private static List<string> AggregateErrors(ValidationResult validationResult)
        {
            var errors = new List<string>();

            if (!validationResult.IsValid)
                foreach (var error in validationResult.Errors)
                    errors.Add(error.ErrorMessage);

            return errors;
        }
    }
}
