using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeApp.WebApi.Models;

namespace PracticeApp.WebApi.Services.Interfaces
{
    public interface IFanService
    {
        public Task<List<Fan>> GetAllFans();
    }
}
