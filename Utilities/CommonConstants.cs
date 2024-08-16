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
        public static string JwtKey = ConfigurationManager.AppSettings["JWT:Key"];
        public static string JwtIssuer = ConfigurationManager.AppSettings["JWT:Issuer"];
        public static string JwtAudience = ConfigurationManager.AppSettings["JWT:Audience"];

    }
}
