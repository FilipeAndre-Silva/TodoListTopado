using FluentValidation.Results;

public class NotificationService : INotificationService
{
    private readonly List<object> _notifications = new List<object>();

    public void AddNotification(Enum message)
    {
        if (string.IsNullOrWhiteSpace(message.GetDescription()))
        {
            throw new ArgumentException("A mensagem da notificação não pode ser nula ou em branco.", nameof(message));
        }

        _notifications.Add(message.GetDescription());
    }

    public void AddNotification(ValidationResult validationResult)
    {
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(e => e.ErrorMessage).ToList()
                );

            var notificationErrorFromValidaiton = new NotificationErrorFromValidaiton()
            {
                ErrorMessage = errors
            };

            _notifications.Add(notificationErrorFromValidaiton);
        }
    }

    public bool HasNotifications()
    {
        return _notifications.Any();
    }

    public IEnumerable<object> GetNotifications()
    {
        return _notifications;
    }

    public void ClearNotifications()
    {
        _notifications.Clear();
    }
}

public class NotificationErrorFromValidaiton
{
    public int StatusCode { get; set; } = 400;
    public string Message { get; set; } = "Validation errors occurred.";
    public Dictionary<string, List<string>>? ErrorMessage { get; set; }
}
