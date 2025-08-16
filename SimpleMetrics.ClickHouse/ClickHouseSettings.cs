namespace SimpleMetrics.ClickHouse;

/// <summary>
/// Настройки ClickHouse
/// </summary>
public class ClickHouseSettings
{
    public const string SectionName = "ClickHouse";

    /// <summary>
    /// Строка подключения
    /// </summary>
    public string ConnectionString { get; set; } = default!;
}
