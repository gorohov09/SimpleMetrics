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
            ) ENGINE = RabbitMQ SETTINGS
                rabbitmq_address = 'amqp://guest:guest@rabbitmq:5672',
                rabbitmq_exchange_name = 'metrics_exchange',
                rabbitmq_format = 'JSONEachRow',
                rabbitmq_exchange_type = 'direct',
                rabbitmq_routing_key_list = 'metrics',
                rabbitmq_queue_base = 'metrics_queue';");

        migrationBuilder.AddRawSqlStatement(@"
            CREATE TABLE metrics
            (
                value Decimal(18, 6),
                timestamp DateTime
            )
            ENGINE = MergeTree() ORDER BY timestamp;");

        migrationBuilder.AddRawSqlStatement(@"
            CREATE MATERIALIZED VIEW metrics_consumer TO metrics
            AS SELECT * FROM metrics_queue;");
    }
}