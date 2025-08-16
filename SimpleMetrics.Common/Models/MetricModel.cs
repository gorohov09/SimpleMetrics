namespace SimpleMetrics.Common.Models;

/// <summary>
/// Модель метрики
/// </summary>
public class MetricModel
{
    /// <summary>
    /// Значение
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// Временная метка
    /// </summary>
    public DateTime Timestamp { get; set; }
}
