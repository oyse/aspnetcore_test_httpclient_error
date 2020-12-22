using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestNotFoundClientIssue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestErrorController : ControllerBase
    {
        [HttpGet("NotFound")]
        public IActionResult GetNotFound()
        {
            throw new MyNotFoundException();
        }
        
        [HttpGet("BadRequest")]
        public IActionResult GetBadRequest()
        {
            throw new MyBadRequestException();
        }
        
    }
}