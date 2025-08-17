using ClickHouse.Facades.Migrations;

namespace SimpleMetrics.ClickHouse.Migrations;

[ClickHouseMigration(202508170115, "AddMetricsMigration")]
public class AddMetricsMigration : ClickHouseMigration
{
    /// <inheritdoc/>
    protected override void Up(ClickHouseMigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddRawSqlStatement(@"
            CREATE TABLE metrics_queue
            (
                value Decimal(18, 6),
                timestamp DateTime
            ) ENGINE = RabbitMQ(my_rabbitmq);");

        migrationBuilder.AddRawSqlStatement(@"
            CREATE TABLE metrics
            (
                value Decimal(18, 6),
                timestamp DateTime
            ) ENGINE = MergeTree() ORDER BY timestamp;");

        migrationBuilder.AddRawSqlStatement(@"
            CREATE MATERIALIZED VIEW metrics_consumer TO metrics
            AS SELECT * FROM metrics_queue;");
    }
}