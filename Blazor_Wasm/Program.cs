using Blazor_Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.SessionStorage;
// 
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// The Scopped Object (Application Level object) for managing all External Calls
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register the ApplicationStateContainerService as a Singleton object
builder.Services.AddSingleton<ApplicationStateContainerService>();
// Add the SessionStorage in DI Container
builder.Services.AddBlazoredSessionStorage();

await builder.Build().RunAsync();
