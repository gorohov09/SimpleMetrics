## Демонстрационный проект для работы с метриками используя ClickHouse + RabbitMq

### Основные задачи
1. Связать ClickHouse и RabbitMq используя необходимый движок (см. https://clickhouse.com/docs/engines/table-engines/integrations/rabbitmq).
2. Реализовать генерацию метрик и отправку их в RabbitMq
3. Реализовать различные методы получения метрик