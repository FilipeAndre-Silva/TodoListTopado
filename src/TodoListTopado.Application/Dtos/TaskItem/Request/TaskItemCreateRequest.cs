using FluentValidation;
using TodoListTopado.Application.Dtos.Base;

namespace TodoListTopado.Application.Dtos.TaskItem.Request
{
    public class CreateTaskItemRequest : ValidatedDtoBase<CreateTaskItemRequest, CreateTaskItemRequestValidator>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
    }

    public enum CreateTaskItemRequestError
    {
        [ErrorDescription("Validation error occurred")]
        Invalid
    }

    public class CreateTaskItemRequestValidator : AbstractValidator<CreateTaskItemRequest>
    {
        public CreateTaskItemRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(1, 100).WithMessage("Title must be between 1 and 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(1, 500).WithMessage("Description must be between 1 and 500 characters.");

            RuleFor(x => x.EstimatedCompletionDate)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Estimated completion date must be in the future or today.")
                .When(x => x.EstimatedCompletionDate.HasValue);
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class ErrorDescriptionAttribute : Attribute
    {
        public string Description { get; }

        public ErrorDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}