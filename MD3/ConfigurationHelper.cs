using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD3
{
    public static class ConfigurationHelper
    {
        public static string GetConnectionString(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath).Trim();
            }
            else
            {
                throw new FileNotFoundException($"The configuration file '{filePath}' was not found.");
            }
        }
    }
}
