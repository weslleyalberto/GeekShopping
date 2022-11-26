using Duende.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project1.Configuration;
using Project1.Initializer;
using Project1.Model.Context;
using Serilog;

namespace Project1
{
    internal static class HostingExtensions
    {
       
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            var connection = builder.Configuration["MySqlConnectionString:MySqlConnectionString"];
            builder.Services.AddDbContext<MySqlContext>(options =>
            {
                options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 31)));
            });
            builder.Services.AddIdentity<Project1.Model.ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MySqlContext>().AddDefaultTokenProviders();
           
           
           /* builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));*/

          /*  builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();*/

            builder.Services
                .AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;

                    // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                    options.EmitStaticAudienceClaim = true;
                })
                .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
                .AddInMemoryApiScopes(IdentityConfiguration.APiScopes)
                .AddInMemoryClients(IdentityConfiguration.Cliets)
                //TODO - verificar porque nao funciona essa classe
                .AddAspNetIdentity<Project1.Model.ApplicationUser>();

            builder.Services.AddScoped<IDbInitialize, DbInitializer>();
            builder.Services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    // register your IdentityServer with Google at https://console.developers.google.com
                    // enable the Google+ API
                    // set the redirect URI to https://localhost:5001/signin-google
                    options.ClientId = "copy client ID from Google here";
                    options.ClientSecret = "copy client secret from Google here";
                });

            return builder.Build();
        }
       
        
           
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            var scope  = app.Services.CreateScope();
            var dbInitialize = scope.ServiceProvider.GetService<IDbInitialize>();
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            
            dbInitialize.Initialize();
            app.MapRazorPages()
                .RequireAuthorization();

            return app;
        }
    }
}