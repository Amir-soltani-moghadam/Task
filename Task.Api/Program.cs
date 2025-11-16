using Task.Application;
using Task.Dapper;
using Task.Persistence;
using Task.UnitOfWork;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureDapperServices(builder.Configuration);
builder.Services.ConfigureUnitOfWorkServices(builder.Configuration);





builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "My Task API";
    config.Version = "v1";
    config.Description = "API for salary calculations and overtime";
    config.DocumentName = "v1";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
