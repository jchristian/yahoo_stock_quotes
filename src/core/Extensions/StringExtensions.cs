using System.Text.RegularExpressions;

namespace YSQ.core.Extensions
{
    internal static class StringExtensions
    {
        public static string RemoveWhitespace(this string str)
        {
            return Regex.Replace(str, @"\s+", "");
        }
    }
}