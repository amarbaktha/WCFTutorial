using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WCFWebClient.Models;
using WCFWebClient.ViewModel;
using WCFWebClient.WeatherServiceReference;
using WCFWebClient.NewsServiceReference;

namespace WCFWebClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Greet(string name)
        {
            //return Content("Welcome to MVC 4, " + name);
            return View();
        }

        public ActionResult About()
        {
            //getting model
            About about = new About();
            about.Name = "Amar Baktha";
            about.Address = "Guindy";
            about.Company = "Harland Clarke";
            //passing model to view
            return View(about);
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "MVC4 Async WCF Service Call";
            var model = new NewsWeatherViewModel();
            model.AddMessage("Starting Action");
            var headlineTask = GetHeadlineAsync(model);
            var temperatureTask = GetCurrentTemperatureAsync(model);

            //await Task.WhenAll(headlineTask, temperatureTask);
            await Task.WhenAny(headlineTask);
            model.AddMessage("Completed all actions");
            return View(model);
        }

        async Task GetCurrentTemperatureAsync(NewsWeatherViewModel model)
        {
            model.AddMessage("Starting Weather Service");
            var weatherClient = new WeatherServiceClient();
            model.Temperature = await weatherClient.GetCurrentTemperatureAsync();
            model.AddMessage("Weather Service Finished");
        }
        async Task GetHeadlineAsync(NewsWeatherViewModel model)
        {
            model.AddMessage("Starting News Service");
            var newsClient = new NewsService1Client();
            model.Headline = await newsClient.GetHeadlinesAsync();
            model.AddMessage("News Service Finished");
        }
    }
}
