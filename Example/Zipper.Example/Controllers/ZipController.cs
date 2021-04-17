using Microsoft.AspNetCore.Mvc;
using Zipper.Example.Models.Zip;
using Zipper.Web.Extensions;

namespace Zipper.Example.Controllers
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

            return this.ZippedFileResult(viewModel.Files);
        }
    }
}
