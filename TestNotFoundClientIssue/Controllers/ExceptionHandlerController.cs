using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestNotFoundClientIssue;

namespace Kariba.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionHandlerController : ControllerBase
    {
       
        [Route("HandleError")]
        public IActionResult HandleError()
        {
            
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var code = HttpStatusCode.InternalServerError;

            var message = "Internal Server Error";

            switch (exception)
            {
                case MyNotFoundException _:
                    code = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
                
                case MyBadRequestException _:
                    code = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;                
            }

            Response.StatusCode = (int) code;

            return Problem(detail: message, statusCode: (int) code);
            
        }
        
    }

}