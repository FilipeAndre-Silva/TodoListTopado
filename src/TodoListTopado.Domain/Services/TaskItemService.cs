using TodoListTopado.Domain.Entities;
using TodoListTopado.Domain.Interfaces;
using TodoListTopado.Domain.Interfaces.Repositories;
using TodoListTopado.Domain.Queries.Request;

namespace TodoListTopado.Domain.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _repository;
        public TaskItemService(ITaskItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskItem>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TaskItem> CreatetAsync(CreateTaskItemCommand command)
        {
            var taskItem = new TaskItem(command.Title, command.Description, command.EstimatedCompletionDate);

            var result = await _repository.CreatetAsync(taskItem);

            return result;
        }

        public async Task<TaskItem> UpdateAsync(TaskItem taskItem, UpdateTaskItemCommand command)
        {
            taskItem.UpdateTaskItem(command);

            var result = await _repository.UpdateAsync(taskItem);

            return result;
        }

        public void RemoveAsync(TaskItem taskItem)
        {
           _repository.RemoveAsync(taskItem);
        }
    }
}