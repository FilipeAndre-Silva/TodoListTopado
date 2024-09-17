using FluentValidation;
using TodoListTopado.Application.Dtos.Base;
using TodoListTopado.Domain.Enums;

namespace TodoListTopado.Application.Dtos.TaskItem.Request
{
    public class UpdateTaskItemRequest : ValidatedDtoBase<UpdateTaskItemRequest, UpdateTaskItemRequestValidator>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
    }

    public enum UpdateTaskItemRequestError
    {
        [ErrorDescription("Validation error occurred")]
        Invalid,

        [ErrorDescription("TaskItem not found")]
        TaskItemNotFound
    }

    public class UpdateTaskItemRequestValidator : AbstractValidator<UpdateTaskItemRequest>
    {
        public UpdateTaskItemRequestValidator()
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
}