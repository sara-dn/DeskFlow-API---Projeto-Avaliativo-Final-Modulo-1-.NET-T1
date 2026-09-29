using Microsoft.EntityFrameworkCore;
using DeskFlow.API.Data;
using DeskFlow.API.Middlewares;

//Creates the builder object that configures the application
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddOpenApi();

//sets up database connection
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

//builds the application
var app = builder.Build();

//Configures middleware use
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
