using System;
using System.Web.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Ca.Skoolbo.Homesite.Services
{
    public class CloudBlobEventService : ICloudBlobEventService
    {
        public Func<string> StorageConnectionString { get; set; }

        private readonly CloudBlobProvider _cloudBlobProvider;
        public CloudBlobEventService()
        {
            _cloudBlobProvider = new CloudBlobProvider();
            if (StorageConnectionString == null)
            {
                StorageConnectionString = () => WebConfigurationManager.AppSettings["StorageConnectionString-Ca"];
            }
        }

        public CloudBlobContainer GetCloudBlobContainer(string containerName)
        {
            var connectionString = StorageConnectionString.Invoke();
            _cloudBlobProvider.SetCloudBlobClient(connectionString);

            var container = _cloudBlobProvider.GetContainerReference(containerName);
            if (container != null)
                container.CreateIfNotExists();

            return container;
        }

        public void UploadObjectToFile(object t, CloudBlobContainer cloudBlobContainer, string blobName)
        {
            _cloudBlobProvider.UploadObjectToFile(t, cloudBlobContainer, blobName.ToLower());
        }

        public T DownloadObjectFormBlob<T>(CloudBlobContainer cloudBlobContainer, string blobName)
        {
            return _cloudBlobProvider.DownloadObjectFormBlob<T>(cloudBlobContainer, blobName);
        }
    }
}