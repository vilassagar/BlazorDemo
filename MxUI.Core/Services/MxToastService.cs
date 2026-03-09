namespace MxUI.Core.Services;

/// <summary>
/// Service for showing toast notifications programmatically.
/// Inject this service and call Show/Success/Error/Warning methods.
/// </summary>
public class MxToastService
{
    public event Action<MxToastMessage>? OnShow;
    public event Action<Guid>? OnDismiss;

    public void Show(string message, MxToastType type = MxToastType.Info, 
                     int durationMs = 5000, string? title = null)
    {
        var toast = new MxToastMessage
        {
            Id = Guid.NewGuid(),
            Message = message,
            Title = title,
            Type = type,
            DurationMs = durationMs,
            CreatedAt = DateTime.UtcNow
        };
        OnShow?.Invoke(toast);
    }

    public void Success(string message, string? title = null, int durationMs = 4000)
        => Show(message, MxToastType.Success, durationMs, title ?? "Success");

    public void Error(string message, string? title = null, int durationMs = 8000)
        => Show(message, MxToastType.Error, durationMs, title ?? "Error");

    public void Warning(string message, string? title = null, int durationMs = 6000)
        => Show(message, MxToastType.Warning, durationMs, title ?? "Warning");

    public void Info(string message, string? title = null, int durationMs = 5000)
        => Show(message, MxToastType.Info, durationMs, title ?? "Info");

    public void Dismiss(Guid id) => OnDismiss?.Invoke(id);
}

public class MxToastMessage
{
    public Guid Id { get; set; }
    public string Message { get; set; } = "";
    public string? Title { get; set; }
    public MxToastType Type { get; set; }
    public int DurationMs { get; set; }
    public DateTime CreatedAt { get; set; }
}

public enum MxToastType { Info, Success, Warning, Error }
