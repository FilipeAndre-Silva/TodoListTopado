using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListTopado.Api.CustomizedResponses;
using TodoListTopado.Application.Dtos.TaskItem.Request;
using TodoListTopado.Application.Interfaces;

namespace TodoListTopado.Api.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskItemApplicationService _taskItemApplicationService;
        private readonly INotificationService _notificationService;

        public TaskController(ITaskItemApplicationService taskItemApplicationService,
                              INotificationService notificationService)
        {
            _taskItemApplicationService = taskItemApplicationService;
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber,[FromQuery] int pageSize)
        {
            var result = await _taskItemApplicationService.GetAllAsync(pageNumber, pageSize);

            return ResponseHandler.GetHandleResponse(_notificationService, Task.FromResult(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var result = await _taskItemApplicationService.GetByIdAsync(id);

            return ResponseHandler.GetHandleResponse(_notificationService, Task.FromResult(result));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTaskItemRequest request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            var result = await _taskItemApplicationService.CreateAsync(request);

            return ResponseHandler.PostHandleResponse(_notificationService, Task.FromResult(result));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateTaskItemRequest request)
        {
            var result = await _taskItemApplicationService.UpdateAsync(id, request);

            return ResponseHandler.PostHandleResponse(_notificationService, Task.FromResult(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var result = await _taskItemApplicationService.DeleteAsync(id);

            return ResponseHandler.PostHandleResponse(_notificationService, Task.FromResult(result));
        }
    }
}