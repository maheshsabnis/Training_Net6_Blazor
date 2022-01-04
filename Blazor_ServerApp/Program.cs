using Blazor_ServerApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. (Dependency Container)
builder.Services.AddRazorPages(); //--> Platform Service to Carry the Blazor UI from Server-to-Client
builder.Services.AddServerSideBlazor(); // --> Manage an execution or Lifecycle of the the Blazor on Server-Side
                                        // Accept Requests over ther SignalR and responds the rendered output
builder.Services.AddSingleton<WeatherForecastService>();

// Application Build for
// 1. HTTP Request Processing Pipeline
// 2. Hosting Environment Build
// 3. Creating Custom ServiceProvider (Some Default Configuration taht is to be executed whne the app is loaded for the first time)
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
