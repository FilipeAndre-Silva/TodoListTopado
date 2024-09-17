using Microsoft.AspNetCore.Mvc;

namespace TodoListTopado.Api.CustomizedResponses
{
    public static class ResponseHandler
    {
        public static IActionResult GetHandleResponse<T>(INotificationService notificationService, Task<List<T>> task)
        {
            var result = task.Result;
            List<object> errors = new List<object>();

            if (notificationService.HasNotifications())
            {
                errors.AddRange(notificationService.GetNotifications().ToList());

                notificationService.ClearNotifications();

                return new BadRequestObjectResult(new { Errors = errors });
            }

            if (!result.Any()) return new NoContentResult();

            return new OkObjectResult(result);
        }

        public static IActionResult GetHandleResponse<T>(INotificationService notificationService, Task<T> task)
        {
            var result = task.Result;
            List<object> errors = new List<object>();

            if (notificationService.HasNotifications())
            {
                errors.AddRange(notificationService.GetNotifications().ToList());

                notificationService.ClearNotifications();

                return new BadRequestObjectResult(new { Errors = errors });
            }

            if (result == null) return new NotFoundResult();

            return new OkObjectResult(result);
        }

        public static IActionResult PostHandleResponse<T>(INotificationService notificationService, Task<T> task)
        {
            var result = task.Result;
            List<object> errors = new List<object>();

            if (notificationService.HasNotifications())
            {
                errors.AddRange(notificationService.GetNotifications().ToList());

                notificationService.ClearNotifications();

                return new BadRequestObjectResult(new { Errors = errors });
            }
            return new OkObjectResult(result);
        }
    }
}