using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using Zipper.Core;

namespace Zipper.Web.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ZippedFileResult(this Controller controller, IEnumerable<IFormFile> files, string fileName = "")
        {
            var zipFileByteArray = Zip.GetZippedFileAsByteArray(files);

            var responseType = MediaTypeNames.Application.Zip;
            fileName ??= $"Zipper_{Guid.NewGuid()}.zip";

            if (!fileName.EndsWith(".zip"))
                fileName += ".zip";

            controller.Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
            return controller.File(zipFileByteArray, responseType);
        }
    }
}
