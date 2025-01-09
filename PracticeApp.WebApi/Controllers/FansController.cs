using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PracticeApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FansController : ControllerBase
    {
        [HttpGet(Name = "GetFans")]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(Ok("Success!"));
        }
    }
}
