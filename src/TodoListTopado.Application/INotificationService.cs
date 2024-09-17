using FluentResults;
using FluentValidation.Results;

public interface INotificationService
{
    bool HasNotifications();
    void AddNotification(Enum message);
    void AddNotification(ValidationResult validationResult);
    void ClearNotifications();
    IEnumerable<object> GetNotifications();
}
