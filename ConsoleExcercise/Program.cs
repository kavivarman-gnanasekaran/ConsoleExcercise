using System.Net;
using System;
using System.Net.Mail;
using SMTP;
using ReadandWrite.cs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using ReadJson;
using JsonReader;
namespace ConsoleForSMTP
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //JsonRead obj = new JsonRead();
            //obj.program();



            //1. creat a service collection for ID
            var serviceCollection = new ServiceCollection();

            //2.Buld a configuration
            IConfiguration configuration;
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("AppSettings.json")
                .Build();

            //3. Add the configuration to the service collection
            serviceCollection.AddSingleton<IConfiguration>(configuration);

            //  // Test obj = new Test(configuration);


              smtp objsmtp = new smtp(configuration);
              objsmtp.FileLog();
            // FileReadandWrite obj = new FileReadandWrite();
            //obj.File();
            // FileWrite obj = new FileWrite();
            //obj.write();
        }
    }
}
