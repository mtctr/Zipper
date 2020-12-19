using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Zipper.Application.Models.Zip
{
    public class ZipFilesViewModel : IValidatableObject
    {
        [DisplayName("Select Files:")]
        public IList<IFormFile> Files { get; set; }

        public ZipFilesViewModel()
        {
            Files = new List<IFormFile>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Files.Any(x => x.Length > 3e6))
                yield return new ValidationResult("Files must have less than 3MB.", new string[] { "Files" });

            if(Files.Count > 5)
                yield return new ValidationResult("You can upload a maximum of 5 files.", new string[] { "Files" });
        }
    }
}
