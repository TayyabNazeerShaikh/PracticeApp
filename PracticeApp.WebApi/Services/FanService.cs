using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeApp.WebApi.Models;
using PracticeApp.WebApi.Services.Interfaces;

namespace PracticeApp.WebApi.Services
{
    public class FanService : IFanService
    {
        private readonly HttpClient _httpClient;

        public FanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Fan>> GetAllFans()
        {
            throw new NotImplementedException();
        }
    }
}
