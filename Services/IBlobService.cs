﻿namespace RedMango_Api.Services
{
    public interface IBlobService
    {
        Task<string> GetBlob(string blobname, string containerName);
        Task<bool> DeleteBlob(string blobname, string containerName);
        Task<string> UploadBlob(string blobname, string containerName, IFormFile file);
    }
}
