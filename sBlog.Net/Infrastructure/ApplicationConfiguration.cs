﻿#region Disclaimer/License Info

/* *********************************************** */

// sBlog.Net

// sBlog.Net is a minimalistic blog engine software.

// Homepage: http://sblogproject.net
// Github: http://github.com/karthik25/sBlog.Net

// This project is licensed under the BSD license.  
// See the License.txt file for more information.

/* *********************************************** */

#endregion
using System.Configuration;

namespace sBlog.Net.Infrastructure
{
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Gets the connection string from the web.config, identified by the key "AppDb" in the "connectionStrings" section
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings["AppDb"];
                return (connectionString != null) ? connectionString.ToString() : null;
            }
        }

        /// <summary>
        /// Gets the name of the hasher type from the web.config, identified by the key "hasher" in the "appSettings" section
        /// This is supposed to be the Fully Qualified Type Name. The default is "sBlog.Net.Domain.Hashers.Md5Hasher"
        /// You could create your own hashers. Have a look at the sample provided
        /// </summary>
        /// <value>
        /// The name of the hasher type.
        /// </value>
        public static string HasherTypeName
        {
            get
            {
                return ConfigurationManager.AppSettings["hasher"];
            }
        }

        private const int DefaultCacheDuration = 5;

        /// <summary>
        /// Gets the duration of the cache identified by the "CacheDuration" key in web.config's "appSettings" section.
        /// If the key is not present a default of "5" is returned
        /// The duration is assumed to be in minutes
        /// </summary>
        /// <value>
        /// The duration of the cache.
        /// </value>
        public static int CacheDuration
        {
            get
            {
                var cacheDuration = ConfigurationManager.AppSettings["CacheDuration"];
                int parsedDuration;
                return int.TryParse(cacheDuration, out parsedDuration) ? parsedDuration : DefaultCacheDuration;
            }
        }
    }
}
