using Microsoft.EntityFrameworkCore;
using TodoListTopado.Domain.Entities;
using TodoListTopado.Domain.Interfaces.Repositories;
using TodoListTopado.Infra.Data;

namespace TodoListTopado.Infra.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly TodoListTopadoDbContext _context;

        public TaskItemRepository(TodoListTopadoDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAllAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 10;
            }

            return await _context.TaskItems
            .Skip((pageNumber - 1) * pageSize) // Pula os registros das páginas anteriores
            .Take(pageSize) // Toma a quantidade de registros especificada
            .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.TaskItems.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TaskItem> CreatetAsync(TaskItem taskItem)
        {
            await _context.TaskItems.AddAsync(taskItem);
            await _context.SaveChangesAsync();

            return taskItem;
        }

        public async Task<TaskItem> UpdateAsync(TaskItem taskItem)
        {
            _context.Entry(taskItem);
            _context.Update(taskItem);
            await _context.SaveChangesAsync();

            return taskItem;
        }

        public async void RemoveAsync(TaskItem taskItem)
        {
            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
        }
    }
}