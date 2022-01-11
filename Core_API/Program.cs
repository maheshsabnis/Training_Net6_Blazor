using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Core_API.CustomMiddleware;


using Core_API.Models;
using Core_API.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register the DbContext in the Services Container
builder.Services.AddDbContext<CompanyContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnStr")); ;
});

// Register The Identity Database in Container
builder.Services.AddDbContext<SecurityDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnStr"));
});

// Lets register the Identity Service. This will Inform to the Application that use the 
// Specific DB Store for Users, Roles and UsersInRole
// This alos Resolves Following Three Class Instances by Registering it in Dependency Container
// UserManager<IdentityUser> and RoleManager<IdentityRole> and SignInManager<IdentityUser>
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<SecurityDbContext>(); // Use the EF Core for Users and Roles Vetrification

// Lets Configure the AuthenticationService
// Configure the Redirection
builder.Services.AddAuthentication();


// Define CORS Policy Service
builder.Services.AddCors(options => {
    options.AddPolicy("cors", policy => { 
       policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


// Register the Repositories
builder.Services.AddScoped<IRepository<Department,int>, DepartmentRepository>();

// Register the AuthenticationService in Dependency Container
builder.Services.AddScoped<AuthenticationService>();

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

// Add The Middleware for Authentication that will use the Authentication Service
app.UseAuthentication();

app.UseAuthorization(); // default to Anonymous



// Use the Customm Middleware so that it will be executed (Run)
app.UseErrorHandlerMiddleware();


// Read the URL and then Read the Controller Name, then Map the Controller name with Route using Route Middleware
// Map the Http request based on it type (Get,Post, Put, Delete) to the Action method of ApiController 
app.MapControllers();

//app.UseEndpoints(endpoints => { 
// endpoints.MapControllers();
//});

app.Run();
