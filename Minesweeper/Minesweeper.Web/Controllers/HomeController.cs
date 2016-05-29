using Minesweeper.Web.Models;
using System;
using System.Web.Mvc;

namespace Minesweeper.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("InvalidModel", "Your input is not valid");
                return View(model);
            }
            else
            {
                ModelState.Clear();
                model.UserResult = model.GenerateOutput(model.UserInput);

                if (!String.IsNullOrEmpty(model.ErroMessage))
                {
                    ModelState.AddModelError("InvalidModel", model.ErroMessage);
                    return View(model);
                }
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}