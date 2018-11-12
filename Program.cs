using Sky.SelfServe.Common;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Logging;

namespace Sky.SelfServe
{
	public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var builtConfig = builder.Build();
                    
                    var keyVaultClient = new KeyVaultClientBuilder()
                        .UseThumbprint(builtConfig["KeyVault:Thumbprint"])
                        .UseClientId(builtConfig["KeyVault:ClientId"])
                        .Build();
                    builder.AddAzureKeyVault(builtConfig["KeyVault:VaultUrl"], keyVaultClient, new DefaultKeyVaultSecretManager());
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .UseStartup<Startup>();
    }
}