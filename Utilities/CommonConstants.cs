using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class CommonConstants
    {
        public static string ApiUrl = ConfigurationManager.AppSettings["is:ApiUrl"];

    }
}
