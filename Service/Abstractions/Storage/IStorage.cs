using Microsoft.AspNetCore.Http;

namespace Service.Abstractions.Storage
{
    public interface IStorage
    {
        Task<(string fileName, string pathOrContainerName)> UploadAsync(string pathOrContainerName, IFormFile files);
        Task DeleteAsync(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
