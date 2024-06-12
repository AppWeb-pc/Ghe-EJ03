
using si730pc2u202218451.API.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730pc2u202218451.API.logistics.Domain.Repositories;
using si730pc2u202218451.API.logistics.Domain.Services;
using si730pc2u202218451.API.logistics.Infrastructure.Persistence.EFC.Repositories;
using si730pc2u202218451.API.Sales.Application.Internal.CommandServices;
using si730pc2u202218451.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730pc2u202218451.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "si730pc2u202218451.API",
                Version = "v1",
                Description = " si730pc2u202218451 API",
                TermsOfService = new Uri("https://purchase-orders.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "u202218451",
                    Email = "contact@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        
        });
        

// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
    });

// Configure Lowercase URLs

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Publishing Bounded Context Injection Configuration

builder.Services.AddScoped<IPurchaseOrdersRepository, PurchaseOrdersRepository>();
builder.Services.AddScoped<IPurchaseOrdersCommandService, PurchaseOrdersCommandService >();

    
var app = builder.Build();

// Validate Database Objects are created
// Add Exception Middleware to ASP.NET Core Pipeline
app.UseMiddleware<ExceptionMiddleware>();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context?.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Add CORS Middleware to ASP.NET Core Pipeline

app.UseCors("AllowAllPolicy");

// Add RequestAuthorization Middleware to ASP.NET Core Pipeline

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();