using Business.Utilities.Validation.Interface;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Utilities.Validation;

public class ValidationHelper : IValidationHelper
{
    private readonly List<IValidator> _validators;

    public ValidationHelper()
    {
        _validators = new List<IValidator>
        {
            new LoginValidator(),
            new RegisterValidator(),
        };
    }

    public async Task<string> ValidateAsync(object obj)
    {
        var error = "Cant Find Validator For The Object Type";

        var validator = _validators.FirstOrDefault(v => v.CanValidateInstancesOfType(obj.GetType()));

        if (validator != null)
        {
            var context = new ValidationContext<object>(obj);

            var result = (ValidationResult) await validator.ValidateAsync(context);

            error = string.Concat(result.Errors.Select(e => e.ErrorMessage.Replace("'", "") + " ")).Trim();
        }

        return error;
    }
}