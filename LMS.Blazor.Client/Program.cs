using LMS.Blazor.Client.Services;
using LMS.Blazor.Client.Services.Implementations;
using LMS.Blazor.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IApiService, ClientApiService>();
builder.Services.AddScoped<IAuthReadyService, AuthReadyService>();

builder.Services.AddSingleton<NavigationStateService>();


builder.Services.AddHttpClient("BffClient", cfg =>
{
    cfg.BaseAddress = new Uri(builder.Configuration["BffClient"] ?? throw new Exception("BffClient address is missing."));
});

builder.Services.AddSingleton<AuthenticationStateProvider,
    PersistentAuthenticationStateProvider>();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

//builder.Services.AddScoped<ICourseService, MockCourseService>();
builder.Services.AddHttpClient<ICourseService, CourseService>(c => {
    c.BaseAddress = new Uri(builder.Configuration["LmsAPIBaseAddress"]!); // https://localhost:7213
});
builder.Services.AddScoped<IModuleService, MockModuleService>();
builder.Services.AddScoped<IActivityService, MockActivityService>();
builder.Services.AddScoped<IParticipantsService, MockParticipantsService>();

await builder.Build().RunAsync();
