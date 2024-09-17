using FluentResults;
using TodoListTopado.Application.Dtos.TaskItem.Request;
using TodoListTopado.Application.Dtos.TaskItem.Response;

namespace TodoListTopado.Application.Interfaces
{
    public interface ITaskItemApplicationService
    {
        Task<List<TaskItemReponse>> GetAllAsync(int pageNumber, int pageSize);
        Task<TaskItemReponse> CreateAsync(CreateTaskItemRequest request);
        Task<TaskItemReponse> UpdateAsync(int id, UpdateTaskItemRequest request);
        Task<TaskItemReponse> GetByIdAsync(int id);
        Task<TaskItemReponse> DeleteAsync(int id);
    }
}