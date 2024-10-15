using API.Extentions;
using API.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .WithOrigins("http://localhost:4200", "https://localhost:4200");
    });
});

// Optional: Add logging
builder.Services.AddLogging();

var app = builder.Build();


app.UseMiddleware<ExceptionMiddleWare>();
// Enable routing
app.UseRouting();

// Enable developer exception page in development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Apply CORS policy
app.UseCors("AllowSpecificOrigin");

// Enable authorization if needed
app.UseAuthorization();
app.UseAuthorization();
// Map controllers
app.MapControllers();

// Optional: Add error handling
app.UseExceptionHandler("/error"); // Custom error handling endpoint

app.Run();
