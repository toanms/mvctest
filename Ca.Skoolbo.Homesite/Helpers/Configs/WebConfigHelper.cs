using System.Web.Configuration;

namespace Ca.Skoolbo.Homesite.Helpers.Configs
{
    public static class WebConfigHelper
    {
        private const string DashboardLinkKey = "DashboardLink";
        private const string BlogKey = "Blog";
        private const string RegisterUrlKey = "RegisterUrl";
        private const string EmailInfoKey = "EmailInfo";
        private const string PhoneNumberKey = "PhoneNumber";

        private const string ApiClientKey = "ApiClient";
        private const string AzurestorageKey = "azurestorage";
        private const string ApiGlobalClientKey = "ApiGlobalClient";
        private const string MasterTokenKey = "MasterToken";
        private const string FolderImageS3Key = "FolderImageS3";

        public static T GetConfig<T>(string key)  where T : class 
        {
            if (string.IsNullOrEmpty(key))
                return default(T);
            var value = WebConfigurationManager.AppSettings[key];
            if (value == null)
                return default(T);

            return ConvertHelper.ConvertToType<T>(value);
        }

        public static string DashboardLink
        {
            get { return GetConfig<string>(DashboardLinkKey); }
        }

        public static string BlogLink
        {
            get { return GetConfig<string>(BlogKey); }
        }

        public static string RegisterUrl
        {
            get { return GetConfig<string>(RegisterUrlKey); }
        }

        public static string EmailInfo
        {
            get { return GetConfig<string>(EmailInfoKey); }
        }

        public static string PhoneNumber
        {
            get { return GetConfig<string>(PhoneNumberKey); }
        }

        public static string ApiClient
        {
            get { return GetConfig<string>(ApiClientKey); }
        }

        public static string Azurestorage
        {
            get { return GetConfig<string>(AzurestorageKey); }
        }

        public static string ApiGlobalClient
        {
            get { return GetConfig<string>(ApiGlobalClientKey); }
        }

        public static string MasterToken
        {
            get { return GetConfig<string>(MasterTokenKey); }
        }
        public static string FolderImageS3
        {
            get { return GetConfig<string>(FolderImageS3Key); }
        }
    }
    
}