using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfiguration _configuration;
        public AppConfiguration(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string ConnectionString
        {
            get
            {
                return _configuration["ConnectionStrings:DBConnection"];
            }
        }

        public string DBKey
        {
            get
            {
                return _configuration["DBKey"];
            }
        }

        public string GetConnectionString()
        {
            //return Encryptor.Decrypt(ConnectionString, DBKey);
            return ConnectionString;
        }

        public IConfigurationSection GetConfigurationSection(string key)
        {
            return this._configuration.GetSection(key);
        }
    }
}
