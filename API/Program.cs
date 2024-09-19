using API.Data; // Assuming your namespace for DataContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure DbContext with SQLite
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .WithOrigins("http://localhost:4200", "https://localhost:4200");
    });
});

var app = builder.Build();

// Enable routing
app.UseRouting();

// Apply CORS policy
app.UseCors("AllowSpecificOrigin");

// Enable authorization if needed
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
