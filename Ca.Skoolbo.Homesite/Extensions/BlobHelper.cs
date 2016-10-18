using Ca.Skoolbo.Homesite.Services;

namespace Ca.Skoolbo.Homesite.Extensions
{
    public class BlobHelper
    {
        private readonly ICloudBlobEventService _cloudBlobEventService;
       

        public BlobHelper()
        {
            _cloudBlobEventService = new CloudBlobEventService();
        }

        public void SaveToBlob(object data)
        {
            var cloudBlob = _cloudBlobEventService.GetCloudBlobContainer("holdingpage".ToLower());

            var blobLeaderboardName = "emailsubscribe.txt".ToLower();

            _cloudBlobEventService.UploadObjectToFile(data, cloudBlob, blobLeaderboardName);
        }
    }
}