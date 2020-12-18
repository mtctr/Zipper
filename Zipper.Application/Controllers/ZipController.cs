using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
    }
}
