using ClickHouse.Facades.Migrations;
using System.Reflection;

namespace SimpleMetrics.ClickHouse.Migrations.Settings;

/// <summary>
/// Класс для поиска миграций
/// </summary>
public class ClickHouseMigrationsLocator : ClickHouseAssemblyMigrationsLocator
{
    /// <summary>
    /// Целевая сборка, где будет происходить поиск миграций
    /// </summary>
    protected override Assembly TargetAssembly => typeof(ClickHouseMigrationsLocator).Assembly;
}