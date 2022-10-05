using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger(options =>
{
    options.RouteTemplate = "docs/{documentName}/openapi.json";
});

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/docs/v1/openapi.json", "My API V1");

    options.RoutePrefix = "docs";
});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
