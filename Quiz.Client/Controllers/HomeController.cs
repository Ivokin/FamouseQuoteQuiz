using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Quiz.Client.Models;

namespace Quiz.Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult GetQuestion()
        {
            string url = "https://localhost:44300/api/quizquestions/";

            HttpWebResponse response = null;


            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)httpWebRequest.GetResponse();

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
