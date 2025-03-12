﻿using BlazorBase.ERPFrontServices.AppDateServices;
using BlazorBase.ERPFrontServices.DineInServices;
using BlazorBase.ERPFrontServices.OrderServices;
using POS.Authorization.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.AddBlazorBootstrap();
builder.AddSerilogService();

builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddSingleton<ApiSettings>(sp =>
    sp.GetRequiredService<IOptions<ApiSettings>>()
        .Value);

builder.Services.AddSingleton<CommonProperties>();
builder.Services.AddSingleton<CartService>();
builder.Services.AddSingleton<Section4ButtonsServices>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddScoped<DineInService>();
builder.Services.AddScoped<AppDateService>();
builder.Services.AddScoped<OrderSettingsService>();



builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

builder.Services.AddHttpClient(builder.Configuration["ApiSettings:ApiName"]!,
    client => { client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]!); })
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        UseCookies = true,  // Ensure authentication cookies are used
        AllowAutoRedirect = true
    });


builder.Services.AddScoped<ICategoryServices, CategoryService>();
builder.Services.AddScoped<ICustomizationSettingsService, CustomizationSettingsService>();

builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
});

builder.Services.AddAuthenticationCore();

builder.Services.AddAuthorization(options =>
{
    foreach (var policy in Permissions.RolePermissions)
    {
        options.AddPolicy(policy.Key, policyBuilder =>
            policyBuilder.RequireClaim("Permission", policy.Value));
    }
});





var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStatusCodePagesWithRedirects("/404");

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();
