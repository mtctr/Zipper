using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;

namespace Zipper.Application.Models.Zip
{
    public class ZipFilesViewModel
    {
        [DisplayName("Select Files:")]
        public IList<IFormFile> Files { get; set; }

        public ZipFilesViewModel()
        {
            Files = new List<IFormFile>();            
        }
    }
}
