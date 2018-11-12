using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Sky.SelfServe.Options;
using Sky.SelfServe.Common;

namespace Microsoft.Azure.Sky.School.Common
{
    public class StorageClient
    {
        private readonly CloudBlobContainer _container;

        public StorageClient(IOptions<SecretOptions> optionsAccessor)
        {
            var secretOptions = optionsAccessor.Value;
            var storageAccount = CloudStorageAccount.Parse(secretOptions.StorageConnection);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            _container = blobClient.GetContainerReference(StorageConstants.ContainerName);
        }

        public async Task<string> GetContent(string blobName)
        {
            string result;
            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(blobName);
            using (MemoryStream stream = new MemoryStream())
            {
                await blockBlob.DownloadToStreamAsync(stream).ConfigureAwait(false);
                result = Encoding.UTF8.GetString(stream.ToArray());
            }

            return result;
        }

        public async Task<string> Upload(string blobName, Stream stream)
        {
            var blockBlob = _container.GetBlockBlobReference(blobName);
            await blockBlob.UploadFromStreamAsync(stream);
            var httpsResult = blockBlob.Uri.ToString().Replace("http://", "https://");

            return httpsResult;
        }

        public async Task UploadContent(string blobName, String xmlString)
        {
            var blockBlob = _container.GetBlockBlobReference(blobName);
            await blockBlob.UploadTextAsync(xmlString);
            //var httpsResult = blockBlob.Uri.ToString().Replace("http://", "https://");
        }
    }
}
