using AutoMapper;
using TodoListTopado.Application.Dtos.TaskItem.Request;
using TodoListTopado.Application.Dtos.TaskItem.Response;
using TodoListTopado.Application.Interfaces;
using TodoListTopado.Domain.Interfaces;
using TodoListTopado.Domain.Queries.Request;

namespace TodoListTopado.Application.Services
{
    public class TaskItemApplicationService : ITaskItemApplicationService
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemService _service;
        private readonly INotificationService _notificationService;

        public TaskItemApplicationService(IMapper mapper, ITaskItemService service, INotificationService notificationService)
        {
            _service = service;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public async Task<List<TaskItemReponse>> GetAllAsync(int pageNumber, int pageSize)
        {
            var result = await _service.GetAllAsync(pageNumber, pageSize);

            return _mapper.Map<List<TaskItemReponse>>(result);
        }

        public async Task<TaskItemReponse> GetByIdAsync(int id)
        {
            if ( id <= 0) return null;
            var result = await _service.GetByIdAsync(id);

            return _mapper.Map<TaskItemReponse>(result);
        }

        public async Task<TaskItemReponse> CreateAsync(CreateTaskItemRequest request)
        {
            if (!request.IsValid())
            {
                _notificationService.AddNotification(request.Validate());
                return null;
            }

            var command = _mapper.Map<CreateTaskItemCommand>(request);

            var result = await _service.CreatetAsync(command);

            if (_notificationService.HasNotifications()) return null;

            return _mapper.Map<TaskItemReponse>(result);
        }

        public async Task<TaskItemReponse> UpdateAsync(int id, UpdateTaskItemRequest request)
        {
            var taskItem = await _service.GetByIdAsync(id);

            if (taskItem == null)
            {
                _notificationService.AddNotification(UpdateTaskItemRequestError.TaskItemNotFound);
                return null;
            }

            if (!request.IsValid())
            {
                _notificationService.AddNotification(request.Validate());
                return null;
            }

            var command = _mapper.Map<UpdateTaskItemCommand>(request);

            var result = await _service.UpdateAsync(taskItem, command);

            if (_notificationService.HasNotifications()) return null;

            return _mapper.Map<TaskItemReponse>(result);
        }

        public async Task<TaskItemReponse> DeleteAsync(int id)
        {
            var taskItem = await _service.GetByIdAsync(id);

            if (taskItem == null)
            {
                _notificationService.AddNotification(UpdateTaskItemRequestError.TaskItemNotFound);
                return null;
            }

            _service.RemoveAsync(taskItem);

            if (_notificationService.HasNotifications()) return null;

            return null;
        }
    }
}