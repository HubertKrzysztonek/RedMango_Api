using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace RedMango_Api.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobCient;

        public BlobService(BlobServiceClient blobClient)
        {
            _blobCient = blobClient;
        }

        public async Task<bool> DeleteBlob(string blobname, string containerName)
        {
            BlobContainerClient blobContainerClient = _blobCient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobname);

            return await blobClient.DeleteIfExistsAsync();
        }

        public async Task<string> GetBlob(string blobname, string containerName)
        {
            BlobContainerClient blobContainerClient = _blobCient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobname);
            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<string> UploadBlob(string blobname, string containerName, IFormFile file)
        {
            BlobContainerClient blobContainerClient = _blobCient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobname);
            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };
            var result = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);
            if (result != null)
            {
                return await GetBlob(blobname, containerName);
            }
            return "";
        }
    }
}
