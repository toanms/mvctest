using System;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Ca.Skoolbo.Homesite.Services
{
    public interface ICloudBlobEventService
    {
        Func<string> StorageConnectionString { get; set; }
        CloudBlobContainer GetCloudBlobContainer(string containerName);
        void UploadObjectToFile(object t, CloudBlobContainer cloudBlobContainer, string blobName);
        T DownloadObjectFormBlob<T>(CloudBlobContainer cloudBlobContainer, string blobName);
    }
}
