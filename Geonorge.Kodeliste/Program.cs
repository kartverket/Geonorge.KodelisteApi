using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



app.UseSwagger();

app.UseSwaggerUI(swagger =>
{
    var url = $"{(!Debugger.IsAttached ? "/codelist" : "")}/swagger/v1/swagger.json";
    swagger.SwaggerEndpoint(url, "Kodeliste-api v1");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
