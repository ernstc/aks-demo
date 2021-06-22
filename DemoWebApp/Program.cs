using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace DemoWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var builtConfig = config.Build();

                    config.AddAzureKeyVault(
                        new Uri(builtConfig["AzureKeyVault:Endpoint"]),
                        new ClientSecretCredential(
                            builtConfig["AzureKeyVault:TenantId"], 
                            builtConfig["AzureKeyVault:ClientId"], 
                            builtConfig["AzureKeyVault:ClientSecret"]
                            ),
                        new KeyVaultSecretManager());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseKestrel((context, serverOptions) =>
                    //{
                    //    serverOptions.Configure(context.Configuration.GetSection("Kestrel"))
                    //        .Endpoint("HTTPS", listenOptions => listenOptions.HttpsOptions.SslProtocols = SslProtocols.Tls12);
                    //});
                });

    }
}
