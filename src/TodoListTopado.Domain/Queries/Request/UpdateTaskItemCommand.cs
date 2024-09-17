using TodoListTopado.Domain.Enums;

namespace TodoListTopado.Domain.Queries.Request
{
    public class UpdateTaskItemCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskItemEnum Status { get; set; }
        public DateTime? EstimatedCompletionDate { get;  set; }
    }
}