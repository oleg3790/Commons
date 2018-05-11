using System.Globalization;

namespace Commons
{
    public static class StringHelper
    {
        public static readonly char[] TrimChars =  { ' ', ',', '\n', '\r', '"', '\t' };

        public static string ToTitleCase( string s )
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }
       
    }
}
