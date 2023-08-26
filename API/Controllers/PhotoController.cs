using Core.Services;
using Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PhotoController : CustomBaseController
    {
        private readonly IPhotoService _photoService;
        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet]
        public IActionResult GetPhotos()
        {
            var photos = _photoService.GetBy(x=>x.Status==Core.Enums.Status.Craeted);
            List<PhotoModel> model = new List<PhotoModel>();
            foreach (var item in photos)
            {
                PhotoModel photo = new PhotoModel()
                {
                    Id = item.Id,
                    Path= item.Path,
                };
                model.Add(photo);
            }
            if(model.Count > 0)
            {
                return CreateActionResult(CustomResponseDto<List<PhotoModel>>.Success(Convert.ToInt32(HttpStatusCode.Ok), model));

            }
            return CreateActionResult(CustomResponseDto<List<PhotoModel>>.Fail(Convert.ToInt32(HttpStatusCode.NotFound), "Data Bulunamadı"));

        }


        [HttpGet("{Id}")]
        public IActionResult GetPhoto(int Id)
        {
            var photo = _photoService.GetById(Id);
            var tag = photo.Tags.Replace("-", ",");
            PhotoModel model = new PhotoModel()
            {
                Id=photo.Id,
                Path=photo.Path,
                Title=photo.Title,
                Tags=tag,
            };
            return CreateActionResult(CustomResponseDto<PhotoModel>.Success(Convert.ToInt32(HttpStatusCode.Ok),model));
        }
          
        [HttpPost]
        public IActionResult AddPhoto(PhotoModel photoModel)
        {
            //_photoService.AddPhotoWithStorage(photoModel);

            return CreateActionResult(CustomResponseDto<PhotoModel>.Success(Convert.ToInt32(HttpStatusCode.Ok)));
        }
        [HttpGet("{Id}")]
        public IActionResult DeletePhoto(int Id)
        {

            var photo = _photoService.GetById(Id);
            photo.Status = Core.Enums.Status.Deleted;
            _photoService.Update(photo);
            return CreateActionResult(CustomResponseDto<PhotoModel>.Success(Convert.ToInt32(HttpStatusCode.Ok)));

        }




    }
}
