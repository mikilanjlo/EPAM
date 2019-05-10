﻿using System;
using System.Collections.Generic;
using NLog;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Kuzmichkin._18
{
    /// <summary>
    /// Provides method that validates string if it's an url 
    /// </summary>
    internal static class URLValidator
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Validates string if it's an url 
        /// </summary>
        /// <param name="urls"></param>
        /// <returns>bool</returns>
        internal static bool ValidateURL(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result)
                logger.Info(string.Format("{0} is not URL", url));

            return result;
        }
    }
}
