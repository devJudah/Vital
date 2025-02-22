using Microsoft.EntityFrameworkCore;
using VitalGuard.API.Data;
using VitalGuard.API.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register the Swagger generator
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// Add DbContext to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
// configure signalr
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();


// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SentryCareSentinel API v1");
    c.RoutePrefix = string.Empty; // This makes Swagger UI available at the root of the application
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.MapControllers();

app.UseCors("AllowAll");

app.UseAuthorization();

// Map SignalR hubs
app.MapHub<PatientHub>("/patientHub"); 

app.UseHttpsRedirection();

app.Run();