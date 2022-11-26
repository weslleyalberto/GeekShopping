using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddHttpClient<IProductService, ProductService>(
    c => c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:ProductAPI"]));
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(c =>
{
    c.DefaultScheme = "Cookies";
    c.DefaultChallengeScheme = "oidc";
    
}).AddCookie("Cookies",c=>
{
    c.ExpireTimeSpan = TimeSpan.FromMinutes(10.0);
}).AddOpenIdConnect("oidc", options =>
{
    options.Authority = builder.Configuration["ServicesUrls:IdentityServer"];
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClientId = "geek_shopping";
    options.ClientSecret = "9244151d-25d1-4ef6-9de7-438e34e2701e";
    options.ResponseType = "code";
    options.ClaimActions.MapJsonKey("role", "role", "role");
    options.ClaimActions.MapJsonKey("sub", "sub", "sub");
    options.TokenValidationParameters.NameClaimType = "name";
    options.TokenValidationParameters.RoleClaimType = "role";
    options.Scope.Add("geek_shopping");
    options.SaveTokens = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(
    end =>
    {
        end.MapControllerRoute(name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
        end.MapRazorPages();
    });
    

app.Run();
