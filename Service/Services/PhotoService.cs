using Core.Entity;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Dto;
using Service.Abstractions.Storage;

namespace Service.Services
{
    public class PhotoService : GenericService<Photo>, IPhotoService
    {
        readonly IStorageService _storageService;
        private readonly IPhotoRepository _photoRepository;
        public PhotoService(IGenericRepository<Photo> repository, IStorageService storageService, IUnitOfWork unitOfWork, IPhotoRepository photoRepository) : base(repository,unitOfWork)
        {
            _storageService = storageService;
            _photoRepository = photoRepository;
        }

        //public async Task AddPhotoWithStorage(PhotoModel photoModel)
        //{
        //    (string fileName, string pathOrContainerName) result =  await _storageService.UploadAsync("upload-images",photoModel.File);

        //    Photo photo = new Photo()
        //    {
        //        CreateDate = DateTime.Now,
        //        FileName = result.fileName,
        //        Path = result.pathOrContainerName,
        //        Title = photoModel.Title,
        //        Tags = photoModel.Tags.Replace(",", "-"),
        //        Status = Core.Enums.Status.Craeted,
        //        Storage = _storageService.StorageName,
        //    };
        //    _photoRepository.Add(photo);         
        //}
    }
}
