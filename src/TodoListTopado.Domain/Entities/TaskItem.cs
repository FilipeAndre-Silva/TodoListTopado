using TodoListTopado.Domain.Enums;
using TodoListTopado.Domain.Queries.Request;

namespace TodoListTopado.Domain.Entities
{
    public class TaskItem
    {
        public TaskItem(string title, string description, DateTime? estimatedCompletionDate)
        {
            Title = title;
            Description = description;
            Status = TaskItemEnum.NotStarted;
            CreationDate = DateTime.Now;
            EstimatedCompletionDate = estimatedCompletionDate;
            CreationDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public TaskItemEnum Status { get; private set; }
        public DateTime? EstimatedCompletionDate { get; private set; }
        public DateTime ActualCompletionDate { get; private set; }
        public DateTime CreationDate { get; private set; }


        public void SetTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void SetDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void StartTask()
        {
            Status = TaskItemEnum.InProgress;
        }

        public void PauseTask()
        {
            Status = TaskItemEnum.OnHold;
        }

        public void CompleteTask()
        {
            Status = TaskItemEnum.Completed;
            ActualCompletionDate = DateTime.Now;
        }

        public void CancelTask()
        {
            Status = TaskItemEnum.Cancelled;
            ActualCompletionDate = DateTime.Now;
        }

        public void UpdateTaskItem(UpdateTaskItemCommand request)
        {
            if (request.Title != null && request.Title != Title)
                Title = request.Title;

            if (request.Description != null && request.Description != Description)
                Description = request.Description;
        }
    }
}