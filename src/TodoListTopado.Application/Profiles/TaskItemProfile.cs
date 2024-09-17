using AutoMapper;
using TodoListTopado.Application.Dtos.TaskItem.Request;
using TodoListTopado.Application.Dtos.TaskItem.Response;
using TodoListTopado.Domain.Entities;
using TodoListTopado.Domain.Queries.Request;

namespace TodoListTopado.Application.Profiles
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<TaskItem, TaskItemReponse>().ReverseMap();
            
            CreateMap<CreateTaskItemRequest, CreateTaskItemCommand>().ReverseMap();
            CreateMap<CreateTaskItemCommand, TaskItemReponse>().ReverseMap();

            CreateMap<UpdateTaskItemRequest, UpdateTaskItemCommand>().ReverseMap();
        }
    }
}