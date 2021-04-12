using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace byudigs.Services
{
    public interface IStorageService
    {
        Task<string> AddItem(IFormFile file, string readerName);
    }

}
