using System;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace Ca.Skoolbo.Homesite.Extensions
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class RegularExpressionCustom : RegularExpressionAttribute
    {
        public RegularExpressionCustom(string regularExpression, Type regularExpressionType, string errorMessageResourceName, Type errorMessageResourceType)
            : base(LoadRegex(regularExpression, regularExpressionType))
        {
            ErrorMessageResourceType = errorMessageResourceType;
            ErrorMessageResourceName = errorMessageResourceName;
        }

        private static string LoadRegex(string key, Type regularExpressionType)
        {
            var resourceManager = new ResourceManager(regularExpressionType);
            var keyRegex = resourceManager.GetString(key);
            return keyRegex;
        }
    }
}
