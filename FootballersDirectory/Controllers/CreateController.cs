using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using FootballersDirectory.Models;
using FootballersDirectory.Repository;

namespace FootballersDirectory.Controllers
{
    public class CreateController : Controller
    {
        private IDataBaseWorker dbWorker;

        public CreateController(IDataBaseWorker dataBaseWorker)
        {
            dbWorker = dataBaseWorker;
        }

        public IActionResult Index()
        {
            var commands = dbWorker.GetAllCommands();
            ViewBag.Commands = commands;

            var genders = dbWorker.GetAllGenders();
            ViewBag.Genders = genders;

            return View("~/Views/Home/Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateFootballer(FootballerEntity footballer)
        {
            await dbWorker.CreateFootballer(footballer);
            return RedirectToAction("Index", "List");
        }
    }
}
