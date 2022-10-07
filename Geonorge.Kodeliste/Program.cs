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

app.UseStaticFiles();

app.UseSwaggerUI(options =>
{
    var url = $"{(!Debugger.IsAttached ? "/codelist" : "")}/docs/v1/openapi.json";
    options.SwaggerEndpoint(url, "Kodeliste-api v1");
    options.InjectStylesheet("/custom.css");

    options.RoutePrefix = "docs";
});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
