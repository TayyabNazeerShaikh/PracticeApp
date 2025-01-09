using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticeApp.WebApi.Services.Interfaces;

namespace PracticeApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FansController : ControllerBase
    {
        private readonly IFanService _fansService;

        public FansController(IFanService fanService)
        {
            _fansService = fanService;
        }

        [HttpGet(Name = "GetFans")]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(Ok("Success!"));
        }
    }
}
