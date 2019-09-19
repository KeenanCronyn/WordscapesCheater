using System;
using System.Collections.Generic;
using System.Linq;

namespace WordscapesCheat.Data
{
    /// <summary>
    /// Static class containing dictionaries and helper functions.
    /// </summary>
    public static class DictionaryInstances
    {
        /// <summary>
        /// Provides access to the 2of12inf dictionary.
        /// </summary>
        public static List<string> TwoOfTwelveInf => 
            CreateDictionaryFromOfTwelveText(Properties.Resources._2of12inf);

        /// <summary>
        /// Splits and cleans a string into a dictionary.
        /// </summary>
        /// <param name="data">The string data.</param>
        /// <returns>A dictionary as a string list.</returns>
        internal static List<string> CreateDictionaryFromOfTwelveText(string data)
        {
            return data.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.TrimEnd(new[] { '%', '!' }))
                .ToList();
        }
    }
}
