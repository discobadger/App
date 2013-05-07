using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Services
{
    public static class StringExtensions
    {
        /// <summary>
        /// Ascertains if a string has a value
        /// </summary>
        /// <param name="check">The check.</param>
        /// <returns>
        ///   <c>true</c> if the specified check is populated; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPopulated(this string check)
        {
            return !string.IsNullOrEmpty(check);
        }
    }
}
