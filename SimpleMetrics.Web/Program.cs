var builder = WebApplication.CreateBuilder(args);
var servies = builder.Services;

servies.AddControllers();
servies.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();