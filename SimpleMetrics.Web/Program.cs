using ClickHouse.Facades.Migrations;
using Microsoft.Extensions.Options;
using SimpleMetrics.ClickHouse;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

var clickHouseSettings = new ClickHouseSettings();
configuration.Bind(ClickHouseSettings.SectionName, clickHouseSettings);
services.AddSingleton(Options.Create(clickHouseSettings));

services.AddControllers();
services.AddOpenApi();
services.AddClickHouse();

var app = builder.Build();
{
    using (var scope = app.Services.CreateScope())
    {
        await scope.ServiceProvider.ClickHouseMigrateAsync();
    }

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}