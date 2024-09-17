using TodoListTopado.Domain.Entities;

namespace TodoListTopado.Domain.Interfaces.Repositories
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItem>> GetAllAsync(int pageNumber, int pageSize);
        Task<TaskItem> CreatetAsync(TaskItem taskItem);
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem> UpdateAsync(TaskItem taskItem);
        void RemoveAsync(TaskItem taskItem);
    }
}