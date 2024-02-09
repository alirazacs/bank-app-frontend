using bank;
using bank_app_frontend.Components;
using BlazorBootstrap;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBlazorBootstrap();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient<HttpClientService>(client =>
{
    client.BaseAddress = new Uri(AppRoutes.SERVER_CONNECTION_STRING);
});
builder.Services.AddScoped<ApplicantService>();
builder.Services.AddScoped<TellerService>();
builder.Services.AddScoped<CustomerService>();
// Register ToastService with the appropriate scope
builder.Services.AddScoped<ToastService>();
builder.Services.AddScoped<ToastMessageService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
