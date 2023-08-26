using Microsoft.AspNetCore.Http;
using Service.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;


namespace Service.Concretes.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task DeleteAsync(string path, string fileName)
      => File.Delete($"{path}\\{fileName}");

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
            => File.Exists($"{path}\\{fileName}");
        async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log!
                throw ex;
            }
        }
        public async Task<(string fileName, string pathOrContainerName)> UploadAsync(string path, IFormFile file)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            (string fileName, string path) data = new();

            string fileNewName = await FileRenameAsync(uploadPath, file.FileName, HasFile);
            await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);

            data.fileName = fileNewName;
            data.path = $"{path}\\{fileNewName}";
            //foreach (IFormFile file in files)
            //{
            //    string fileNewName = await FileRenameAsync(uploadPath, file.FileName, HasFile);

            //    await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
            //    datas.Add((fileNewName, $"{path}\\{fileNewName}"));
            //}

            return data;
        }
    }
}
