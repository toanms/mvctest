using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ca.Skoolbo.Homesite.Models
{
    public static class MyExtension
    {
        public static DateTime? ToDateTimeOrDefault(this string text, DateTime? _default)
        {
            try
            {
                return DateTime.Parse(text);
            }
            catch
            {
                return _default;
            }
        }
    }
}