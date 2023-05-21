using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Config
    {
        /// <summary>
        /// Retrieves the connection string from the configuration file.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings
               ["TaskTrackerDBConnectionString"].ConnectionString;
            }
        }
    }
}
