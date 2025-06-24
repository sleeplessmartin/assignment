using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddControllers();

services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

await services.AddApplicationAsync();
services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline. Central Exception Handler Middleware
// This middleware will handle exceptions globally and return appropriate responses.
// This is to avoid putting try-catch blocks in every controller action.
app.UseMiddleware<AssignmentExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();