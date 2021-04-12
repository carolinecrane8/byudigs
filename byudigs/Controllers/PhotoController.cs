using byudigs.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace byudigs.Controllers
{
    public class PhotoController : Controller
    {

        private readonly S3StorageService _s3Storage;

        public IActionResult Index()
        {
            return View();
        }

        public PhotoController(ILogger<PhotoController> logger, S3StorageService storage)
        {
            _s3Storage = storage;
        }

        [HttpPost]
        public async Task<IActionResult> SavePhotos(SavePhotosViewModel SavePhoto, int BurialId)
        {
            if (ModelState.IsValid)
            {
                string url = await _s3Storage.AddItem(SavePhoto.PhotoFile, "Test");
                Burial burial_to_add = _context.Burial.Where(b => b.BurialId == BurialId).FirstOrDefault
            }
            FileUrl FileRecord = new FileUrl(_context)
            {
                Url = Url,
                Type = SavePhoto.Type,
                Burial = burial_to_add,
                BurialId = burial_to_add.BurialId
            };

            _context.Add(FileRecord);
            _context.SaveChanges();
            return Redirect("/Home");
        }
    }
}
