using Microsoft.Extensions.DependencyInjection;
using TodoListTopado.Domain.Interfaces;
using TodoListTopado.Domain.Services;

namespace TodoListTopado.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDomainServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<ITaskItemService, TaskItemService>();
        }
    }
}