using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using FootballersDirectory.Repository;
using FootballersDirectory.Models;
using System.Collections.Generic;

namespace FootballersDirectory.Controllers
{
    public class ListController : Controller
    {
        private IDataBaseWorker dbWorker;

        public ListController(IDataBaseWorker dataBaseWorker)
        {
            dbWorker = dataBaseWorker;
        }

        public async Task<IActionResult> Index()
        {
            List<FootballerEntity> footbaleersList = await dbWorker.GetAllFootballers();

            var commands = dbWorker.GetAllCommands();
            ViewBag.Commands = commands;

            var genders = dbWorker.GetAllGenders();
            ViewBag.Genders = genders;

            return View("~/Views/Home/List.cshtml", footbaleersList);
        }

        [HttpGet]
        public async Task<IActionResult> EditFootballer(int? id)
        {
            if (id != null)
            {
                FootballerEntity footballer = await dbWorker.EditFootballer(id);
                var commands = dbWorker.GetAllCommands();
                ViewBag.Commands = commands;

                var genders = dbWorker.GetAllGenders();
                ViewBag.Genders = genders;
                return PartialView("/Views/Home/_Edit.cshtml", footballer);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFootballer(int? id)
        {
            await dbWorker.DeleteFootballerById(id);
            return RedirectToAction("Index", "List");
        }

        [HttpPost]
        public async Task<IActionResult> EditConfirm(FootballerEntity footballer)
        {
            await dbWorker.EditConfirm(footballer);
            return RedirectToAction("Index", "List");
        }
    }
}
