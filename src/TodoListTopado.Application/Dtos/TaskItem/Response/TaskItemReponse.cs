using TodoListTopado.Domain.Enums;

namespace TodoListTopado.Application.Dtos.TaskItem.Response
{
    public class TaskItemReponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskItemEnum Status { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}