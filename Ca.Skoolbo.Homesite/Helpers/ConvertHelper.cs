using System.ComponentModel;

namespace Ca.Skoolbo.Homesite.Helpers
{
    public static class ConvertHelper
    {
        public static T ConvertToType<T>(string value)
        {
            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(value);
        }
    }
}