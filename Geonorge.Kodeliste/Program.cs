using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Kodeliste-API",
        Description = "Henter ut kodelister som benyttes for datasett",
        Contact = new OpenApiContact
        {
            Name = "Geonorge",
            Url = new Uri("https://www.geonorge.no/aktuelt/om-geonorge/")
        },
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

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
    url = $"{(!Debugger.IsAttached ? "/codelist" : "")}/custom.css";
    options.InjectStylesheet(url);

    options.RoutePrefix = "docs";
});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
