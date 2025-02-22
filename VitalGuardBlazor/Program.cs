using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using VitalGuardBlazor;
using VitalGuardBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register SignalR service
builder.Services.AddSingleton<SignalRService>();

// Register SignalR client to use in the app
builder.Services.AddSingleton(sp => new HubConnectionBuilder()
    .WithUrl("https://localhost:5001/patientHub")  // Update URL to match your backend SignalR server URL
    .Build());

await builder.Build().RunAsync();
