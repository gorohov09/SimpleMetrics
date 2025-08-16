using ClickHouse.Facades.Migrations;
using Microsoft.Extensions.Options;

namespace SimpleMetrics.ClickHouse.Migrations.Settings;

/// <summary>
/// Настройки для миграций
/// </summary>
public class ClickHouseMigrationInstructions : IClickHouseMigrationInstructions
{
    private readonly string _connectionString;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="clickHouseSettings">Настройки ClickHouse</param>
    public ClickHouseMigrationInstructions(IOptions<ClickHouseSettings> clickHouseSettings)
        => _connectionString = clickHouseSettings.Value.ConnectionString ?? throw new ArgumentNullException(nameof(clickHouseSettings));

    /// <summary>
    /// Получить строку подключения
    /// </summary>
    /// <returns>Строка подключения</returns>
    public string GetConnectionString() => _connectionString;
}