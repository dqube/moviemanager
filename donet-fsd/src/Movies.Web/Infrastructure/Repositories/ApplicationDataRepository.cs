using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Movies.Client.Core.Infrastructure.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Infrastructure.Repositories
{
    public class ApplicationDataRepository : IApplicationDataRepository
    {
        public ApplicationDataRepository(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(env.ContentRootPath)
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                          .AddEnvironmentVariables();
            configuration = builder.Build();

        }
        public IConfiguration configuration { get; }
        public bool? GetOptionalBooleanFromApplicationData(string key, bool? defaultValue)
        {
            var resultStr = configuration[key];
            bool result;
            if (!bool.TryParse(resultStr, out result) && defaultValue.HasValue)
            {
                result = defaultValue.Value;
            }
            return result;
        }

        public int? GetOptionalIntegerFromApplicationData(string key, int? defaultValue)
        {
            var resultStr = configuration[key];
            int result;
            if (!int.TryParse(resultStr, out result) && defaultValue.HasValue)
            {
                result = defaultValue.Value;
            }
            return result;
        }

        public string GetStringFromApplicationData(string key, string defaultValue)
        {
            var result = configuration[key];
            if (result == null)
            {
                result = defaultValue;
            }
            return result;
        }

        public void SetStringToApplicationData(string key, string value)
        {
            //configuration.
            //appSettings.Set(key, value);
            throw new NotImplementedException();
        }
    }
}
