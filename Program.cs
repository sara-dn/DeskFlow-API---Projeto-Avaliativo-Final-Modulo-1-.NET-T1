using Microsoft.EntityFrameworkCore;
using DeskFlow.API.Data;
using DeskFlow.API.Middlewares;
using DeskFlow.API.Services.Interfaces;
using DeskFlow.API.Services;
using DeskFlow.API.Repositories.Interfaces;
using DeskFlow.API.Repositories;

//Creates the builder object that configures the application
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddOpenApi();

builder.Services.AddControllers();

//dependency injections
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
//sets up database connection
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

//builds the application
var app = builder.Build();

//Configures middleware use
//app.UseMiddleware<ExceptionHandlingMiddleware>();

//maps the controllers to the application duh
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
        app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
    });
}

//app.UseHttpsRedirection();

app.Run();
