using Dto;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEB.APIHandler;
using WEB.FileUploads;
using WEB.Models;

namespace WEB.Controllers
{
    public class HomeController : CustomBaseController
    {
        private readonly IFileUpload _fileUpload;
        public HomeController(IApiHandler apiHandler, IConfiguration configuration, IFileUpload fileUpload) : base(apiHandler, configuration)
        {
            _fileUpload = fileUpload;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DeletePhoto(int Id)
        {
            var model = _apiHandler.GetApi<CustomResponseDto<PhotoModel>>(_url + UrlStrings.DeletePhoto+Id);
            return RedirectToAction("MyPhotos");
        }

        public IActionResult GetPhoto(int Id)
        {
            var model = _apiHandler.GetApi<CustomResponseDto<PhotoModel>>(_url + UrlStrings.GetPhoto+Id);
            return PartialView("_photopopup",model.Data);
        }
        [Route("/Home/MyPhotos")]
        public IActionResult MyPhotos()
        {
            var model = _apiHandler.GetApi<CustomResponseDto<List<PhotoModel>>>(_url + UrlStrings.GetPhotos);
            return View(model.Data);

        }
        [Route("/Home/AddPhoto")]
        [HttpGet]
        public IActionResult AddPhoto()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddPhoto(PhotoModel photoModel,IFormFile formFile)
        {
            if(formFile != null)
            {
                photoModel.Path = _fileUpload.FileUploads(formFile);
            }
            photoModel.FileName = formFile.FileName;
            photoModel.Storage = "";
            var model = _apiHandler.PostApi<CustomResponseDto<PhotoModel>>(photoModel,_url + UrlStrings.AddPhoto);
            return RedirectToAction("MyPhotos");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}