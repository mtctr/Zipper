using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.IO.Compression;
using System.Net.Mime;
using Zipper.Application.Models.Zip;

namespace Zipper.Application.Controllers
{
    public class ZipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ZipFilesViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            byte[] zipFile;
            var zipStream = new MemoryStream();
            zipStream.Seek(0, SeekOrigin.Begin);

            using (ZipArchive zip = new (zipStream, ZipArchiveMode.Create, true))
            {
                foreach (var file in viewModel.Files)
                {
                    var entry = zip.CreateEntry($"{file.FileName}");
                    using(Stream entryStream = entry.Open())
                    {
                        file.CopyTo(entryStream);
                    }
                }
            }

            zipFile = zipStream.ToArray();
            zipStream.Flush();

            var responseType = MediaTypeNames.Application.Zip;
            var fileName = $"Zipper_{Guid.NewGuid()}.zip";
            Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
            return File(zipFile, responseType);
        }
    }
}
