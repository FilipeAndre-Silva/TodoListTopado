// src/Application/Dtos/Base/BaseValidatedDto.cs
using FluentResults;
using FluentValidation;
using FluentValidation.Results;

namespace TodoListTopado.Application.Dtos.Base
{
    public abstract class ValidatedDtoBase<TDto, TValidator>
        where TDto : ValidatedDtoBase<TDto, TValidator>
        where TValidator : AbstractValidator<TDto>, new()
    {
        public ValidationResult Validate()
        {
            var validator = new TValidator();
            var validationResult = validator.Validate(this as TDto);
        
            return validationResult;
        }

        public bool IsValid()
        {
            var validator = new TValidator();
            var validationResult = validator.Validate(this as TDto);

            return validationResult.IsValid;
        }
    }

    public class ValidationErrorResponse : IError
    {
        public string Field { get; set; }
        public string[] Messages2 { get; set; }

        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => throw new NotImplementedException();

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }

}