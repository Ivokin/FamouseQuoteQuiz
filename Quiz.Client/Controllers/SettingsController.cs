using Microsoft.AspNetCore.Mvc;

namespace Quiz.Client.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult submit(string button)
        {
            if (button.Equals("binary"))
            {
                return View();
            }
            else
            {

            }

            return View();
        }

        public ActionResult button(string button)
        {
            if (button.Equals("binary"))
            {
                return View();
            }
            else
            {

            }

            return View();
        }
    }
}