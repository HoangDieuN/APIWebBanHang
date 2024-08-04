using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IAppConfiguration
    {
        string ConnectionString { get; }
        string DBKey { get; }

        string GetConnectionString();

        IConfigurationSection GetConfigurationSection(string Key);
    }
}
