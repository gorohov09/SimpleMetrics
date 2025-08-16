using ClickHouse.Facades;
using Microsoft.Extensions.DependencyInjection;
using SimpleMetrics.ClickHouse.Migrations.Settings;

namespace SimpleMetrics.ClickHouse;

/// <summary>
/// Класс - входная точка проекта, регистрирующий реализованные зависимости текущим проектом
/// </summary>
public static class Entry
{
    /// <summary>
    /// Добавить службы проекта
    /// </summary>
    /// <param name="services">Коллекция служб</param>
    /// <returns>Обновленная коллекция служб</returns>
    public static IServiceCollection AddClickHouse(this IServiceCollection services)
    {
        services.AddClickHouseMigrations<ClickHouseMigrationInstructions, ClickHouseMigrationsLocator>();
        return services;
    }
}
