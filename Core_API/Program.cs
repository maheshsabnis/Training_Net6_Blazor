using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


using Core_API.Models;
using Core_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register the DbContext in the Services Container
builder.Services.AddDbContext<CompanyContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnStr")); ;
});

// Define CORS Policy Service
builder.Services.AddCors(options => {
    options.AddPolicy("cors", policy => { 
       policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


// Register the Repositories
builder.Services.AddScoped<IRepository<Department,int>, DepartmentRepository>();

// Supress the Default Camesl Casing Serialization for JSON
builder.Services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null) ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// The Builder Objects for Middlewares
// Define objects those are added in HttpContext aka Http Pipeline
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configure the CORS Middleware
app.UseCors("cors");

app.UseAuthorization(); // default to Anonymous

// Read the URL and then Read the Controller Name, then Map the Controller name with Route using Route Middleware
// Map the Http request based on it type (Get,Post, Put, Delete) to the Action method of ApiController 
app.MapControllers();

//app.UseEndpoints(endpoints => { 
// endpoints.MapControllers();
//});

app.Run();
