namespace TodoListTopado.Domain.Queries.Request
{
    public class CreateTaskItemCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
    }
}