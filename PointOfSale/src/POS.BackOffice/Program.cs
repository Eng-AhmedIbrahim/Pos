using BlazorBase.API;
using Microsoft.AspNetCore.Authentication.Cookies; // ✅ Add this for cookie authentication
using Microsoft.Extensions.Options;
using POS.Authorization.Models;
using POS.BackOffice;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddSingleton<ApiSettings>(sp =>
    sp.GetRequiredService<IOptions<ApiSettings>>()
        .Value);

builder.Services.AddHttpClient(builder.Configuration["ApiSettings:ApiName"]!,
    client => { client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]!); });

// ✅ Add authentication services properly
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // Redirect to login page if not authenticated
        options.AccessDeniedPath = "/access-denied"; // Redirect to access denied page
    });

builder.Services.AddAuthorization(options =>
{
    foreach (KeyValuePair<string, string> policy in Permissions.RolePermissions)
    {
        options.AddPolicy(policy.Key, policyBuilder =>
            policyBuilder.RequireClaim("Permission", policy.Value));
    }
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // ✅ Ensure this is before Authorization
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
