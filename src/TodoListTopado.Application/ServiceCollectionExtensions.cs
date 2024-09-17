using Microsoft.Extensions.DependencyInjection;
using TodoListTopado.Infra;
using TodoListTopado.Domain;
using TodoListTopado.Application.Interfaces;
using TodoListTopado.Application.Services;
using FluentValidation;
using TodoListTopado.Application.Dtos.TaskItem.Request;

namespace TodoListTopado.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddInfraDependency();
            services.AddDomainServiceDependency();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ITaskItemApplicationService, TaskItemApplicationService>();

            services.AddTransient<IValidator<CreateTaskItemRequest>, CreateTaskItemRequestValidator>();
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}