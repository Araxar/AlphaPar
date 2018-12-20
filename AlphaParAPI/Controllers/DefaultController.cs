using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlphaParAPI.Controllers
{
    [Route("")]
    [ApiController]
    [AllowAnonymous]
    public class DefaultController : ControllerBase
    {
        [HttpGet("")]
        public ActionResult<string> HelloWorld()
        {
            return "Hello World";
        }
    }
}