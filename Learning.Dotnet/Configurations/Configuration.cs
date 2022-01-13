using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Learning.Dotnet.Configurations
{
    public class Configuration
    {
        private string[] args;
        public Configuration(string[] args)
        {
            this.args = args;
            // ConfigWithoutSwitch();
            // ConfigWithSwitch();
            ConfigSection();
        }

        /*
         * commandline config: dotnet run appsettings.json --Database MongoDB --Logging:LogLevel:Microsoft=Info
         * commandline config: dotnet run appsettings.json /Database=MongoDB /Logging:LogLevel:Microsoft=Info
         */
        private void ConfigWithoutSwitch()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .Build();
            Console.WriteLine($"DB:{configurationRoot["Database"]}, Logging: {configurationRoot["Logging:LogLevel:Microsoft"]}");
        }

        /*
         * commandline config with Dictionary: dotnet run appsettings.json -db=MongoDB --ms-log=Info 
         */
        private void ConfigWithSwitch()
        {
            var switchMappings = new Dictionary<string, string>()
            {
                {"-db", "Database"},
                {"--ms-log", "Logging:LogLevel:Microsoft"},
            };
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args, switchMappings) 
                .Build();
            Console.WriteLine($"DB:{configurationRoot["Database"]}, Logging: {configurationRoot["Logging:LogLevel:Microsoft"]}");
        }

        /*
         * commandline config: dotnet run appsettings.json --Database MongoDB --Logging:LogLevel:Microsoft=Info
         */
        private void ConfigSection()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .Build();
            IConfiguration DB = configurationRoot.GetSection("Database"); // Not working
            IConfiguration Log = configurationRoot.GetSection("Logging:LogLevel"); // Working
            Console.WriteLine($"DB:{DB["Database"]}, Logging: {Log["Microsoft"]}");
        }
    }
}