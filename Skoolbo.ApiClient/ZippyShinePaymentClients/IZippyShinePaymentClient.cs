using Skoolbo.ApiClient.Models.ZippyShinePaymentModel;

namespace Skoolbo.ApiClient.ZippyShinePaymentClients
{
    public interface IZippyShinePaymentClient
    {
        ZippyLicenseModel GetLicenseByKey(string key);
    }
}