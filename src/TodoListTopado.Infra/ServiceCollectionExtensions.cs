using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoListTopado.Domain.Interfaces.Repositories;
using TodoListTopado.Infra.Data;
using TodoListTopado.Infra.Repositories;

namespace TodoListTopado.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfraDependency(this IServiceCollection services)
        {
            services.AddDbContext<TodoListTopadoDbContext>(options => options.UseSqlite("Data Source=TodoListTopado.db"));

            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
        }
    }
}