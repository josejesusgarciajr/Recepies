using System;
using System.Globalization;
using System.Linq;

namespace PersonalPlayGround.Extensions
{
    public static class StringExtensions
    {
        public static string Reverse(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
        public static bool IsPalindrome(this string text, StringComparison stringComparison)
        {
            string reversed = Reverse(text);

            return string.Equals(text, reversed, stringComparison);
        }

        public static string ToPascalCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text).Replace(" ", string.Empty);
        }
    }
}