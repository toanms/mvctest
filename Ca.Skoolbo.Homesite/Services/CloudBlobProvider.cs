using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace Ca.Skoolbo.Homesite.Services
{
    public class CloudBlobProvider
    {
        private CloudBlobClient _cloudBlobClient;


        public CloudStorageAccount CloudAccount(string connectionString)
        {
           return CloudStorageAccount.Parse(connectionString);
        }

        public void SetCloudBlobClient(string connectionString)
        {
            _cloudBlobClient = CloudAccount(connectionString).CreateCloudBlobClient();
        }
            
        #region Blob
        public CloudBlobContainer GetContainerReference(string containerName)
        {
            if (_cloudBlobClient == null)
                return null;

            return _cloudBlobClient.GetContainerReference(containerName);
        }

        public void UploadObjectToFile(object t, CloudBlobContainer cloudBlobContainer, string blobName)
        {
           
            var blockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
            if (blockBlob != null)
            {
                var newData = t.ToString();
                try
                {
                    var data = blockBlob.DownloadText();
                    if (!string.IsNullOrEmpty(data))
                    {
                        newData = data + ";" + newData;
                    }    
                }
                catch (Exception)
                {
                    
                }

                blockBlob.UploadText(newData);
            }
            
        }

        public T DownloadObjectFormBlob<T>(CloudBlobContainer cloudBlobContainer, string blobName)
        {
            var blockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);

            var jsonString = blockBlob.DownloadText();
            if (string.IsNullOrEmpty(jsonString))
                return default(T);

            return JsonConvert.DeserializeObject<T>(jsonString);
        } 
        #endregion
    }
}
