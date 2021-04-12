using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace byudigs.Models
{
    public class SavePhotosViewModel
    {

        [Required]
        public IFormFile PhotoFile { get; set; }
        public string Type { get; set; }
        public Burial Burial { get; set; }
    }
}
