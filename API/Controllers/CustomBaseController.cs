using Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
        [Route("[controller]/[action]")]
        [ApiController]
        public class CustomBaseController : ControllerBase
        {

            public CustomBaseController()
            {
            }

            public enum HttpStatusCode
            {
                NotFound = 404,
                BadRequest = 404,
                UnSporttedMediaType = 415,
                Created = 201,
                NoContent = 204,
                Ok = 200

            }

            public enum EntityStatus
            {
                Passive = 2,
                Active = 1,
                AwaitingResponseDiveCenter = 0
            }

            /// <summary>
            /// Api tarafındaki dönüş türümüzü custom response dto ile çevrelememizi sağlayan
            /// yapıddır.
            /// </summary>
            /// <typeparam name="T">Apı tarafından hangi datayı döneceğimizi buraya
            /// generic olarak belirtiriz.</typeparam>
            /// <param name="response">REsponse olarak da customresponsedto türünden
            /// bir dönüş değeri alır. içerisinde generic T nesnesi ile.</param>
            /// <returns></returns>
            [NonAction]
            public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
            {
                if (response.StatusCode == 204)
                    return new ObjectResult(null)
                    {
                        StatusCode = response.StatusCode
                    };

                return new ObjectResult(response)
                {
                    StatusCode = response.StatusCode
                };
            }
        }
}
