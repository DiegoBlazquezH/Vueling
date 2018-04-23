using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Common.Helpers
{
    class ConfigurationHelper
    {
        private static string GetConfVariable(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
