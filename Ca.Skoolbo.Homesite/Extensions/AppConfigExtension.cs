using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.Configuration;

namespace Ca.Skoolbo.Homesite.Extensions
{
    public static class AppConfigExtension
    {
        public static T GetValueCustomSettings<T>(string key, string section)
        {
            if (string.IsNullOrEmpty(key))
                return default(T);

            var projectSettingsSection = WebConfigurationManager.GetSection(section);
            if (projectSettingsSection == null)
                return default(T);

            var projectSettings = projectSettingsSection as NameValueCollection;
            if (projectSettings == null)
                return default(T);

            var value = projectSettings[key];
            if (value == null)
                return default(T);

            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(value);
        }
        public static T GetValueAppConfig<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
                return default(T);

            var value = WebConfigurationManager.AppSettings[key];
            if (value == null)
                return default(T);

            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(value);
        }
    }
}