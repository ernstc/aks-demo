using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DemoWebApp2.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;


namespace DemoWebApp2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("SqlDatabase");
            services.AddDbContext<DemoDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            services
                .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));

            // # The code below apply the Authorize filter to all controllers.
            //services.AddControllers(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //});

            // # The code below enable authorization for all Razor Pages.
            services.AddRazorPages(options => 
            {
                options.Conventions.AuthorizeFolder("/");
            });

            // # The code below is needed for let the applicatin working behind a reverse proxy like NGINX.
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

                options.KnownProxies.Add(IPAddress.Parse("10.0.177.47"));
                options.KnownNetworks.Add(new IPNetwork(IPAddress.Parse("10.0.0.0"), 16));
                options.KnownNetworks.Add(new IPNetwork(IPAddress.Parse("10.244.0.0"), 16));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // # Enable logging for the authentication flow. Usefull for debugging only.
            //IdentityModelEventSource.ShowPII = true;

            // # Log the headers of each request received. Userfull for debugging what the application receives from the proxy.
            //app.Use((context, next) =>
            //{
            //    Console.WriteLine("----------------------------------------");
            //    Console.WriteLine($"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");
            //    Console.WriteLine();
            //    foreach (var header in context.Request.Headers)
            //    {
            //        Console.WriteLine($"{header.Key}: {header.Value}");
            //    }
            //    Console.WriteLine();

            //    return next();
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseForwardedHeaders();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseForwardedHeaders();
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
