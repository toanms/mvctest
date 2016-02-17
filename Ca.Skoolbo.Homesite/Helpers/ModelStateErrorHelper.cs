using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ca.Skoolbo.Homesite.Helpers
{
    public static class ModelStateErrorHelper
    {
        public const string ItemId = "ItemId";
        public static T GetModelStateError<T>(this TempDataDictionary tempDataDictionary, ModelStateDictionary modelState, string key = "ErrorValidation") where T : class, new()
        {
            if (tempDataDictionary[key] == null)
                return default(T);

            var tempData = tempDataDictionary[key] as Dictionary<string, object>;

            if (tempData == null)
                return default(T);

            var errors = tempData["Error"] as List<KeyValuePair<string, ModelErrorCollection>>;
            if (errors == null)
            {
                return tempData["Data"] as T;
            }
            foreach (var item in errors)
            {
                foreach (var erro in item.Value)
                {
                    modelState.AddModelError(item.Key, erro.ErrorMessage);
                }
            }
            return tempData["Data"] as T;
        }

        public static void SetModelStateError(this TempDataDictionary tempDataDictionary, ModelStateDictionary modelState, object data, string key = "ErrorValidation")
        {
            var errorList = modelState.Where(c => c.Value.Errors.Count > 0).Select(item =>
                new KeyValuePair<string, ModelErrorCollection>(item.Key, item.Value.Errors)).ToList();

            var error = new Dictionary<string, object>
            {
                {"Error", errorList}, 
                {"Data", data}
            };
            tempDataDictionary[key] = error;
        }
    }
}