using Blazor_GameStoreApp.Components;
using Blazor_GameStoreApp.Components.Controllers;
using Blazor_GameStoreApp.Components.Model;



var builder = WebApplication.CreateBuilder(args);

var gameStoreApiUri = builder.Configuration["GameStoreAPI"]??
    throw new Exception("GameStoreAPI is not set");

builder.Services.AddHttpClient<GameDb>(client=>client.BaseAddress=new Uri(gameStoreApiUri));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<Game>();
builder.Services.AddSingleton<DeleteGame>();
builder.Services.AddSingleton<EditGame>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
