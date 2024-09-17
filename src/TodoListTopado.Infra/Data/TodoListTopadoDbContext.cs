using Microsoft.EntityFrameworkCore;
using TodoListTopado.Domain.Entities;

namespace TodoListTopado.Infra.Data
{
    public class TodoListTopadoDbContext : DbContext
    {
        public TodoListTopadoDbContext(DbContextOptions<TodoListTopadoDbContext> options) 
        : base(options)
        { }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}