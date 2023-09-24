namespace RedMango_Api.Services
{
    public class BlobService : IBlobService
    {
        public Task<string> DeleteBlob(string blobname, string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetBlob(string blobname, string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadBlob(string blobname, string containerName, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
