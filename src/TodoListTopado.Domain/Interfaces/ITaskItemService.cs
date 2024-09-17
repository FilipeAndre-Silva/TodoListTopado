using TodoListTopado.Domain.Entities;
using TodoListTopado.Domain.Queries.Request;

namespace TodoListTopado.Domain.Interfaces
{
    public interface ITaskItemService
    {
        Task<List<TaskItem>> GetAllAsync(int pageNumber, int pageSize);
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem> CreatetAsync(CreateTaskItemCommand command);
        Task<TaskItem> UpdateAsync(TaskItem taskItem, UpdateTaskItemCommand command);
        void RemoveAsync(TaskItem taskItem);
    }
}