using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IHttpClientDemo.Models;
using System.Net.Http;

namespace IHttpClientDemo.Controllers
{
    public class HomeController : Controller
    {
		IHttpClientFactory httpClientFactory { get; set; }

		public HomeController(IHttpClientFactory httpClientFactory)
		{
			this.httpClientFactory = httpClientFactory;	
		}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		[HttpGet]
		public async Task<IActionResult> Test()
		{
			var reqresHttpclient = httpClientFactory.CreateClient("reqres");
			var reqresResult = await reqresHttpclient.GetStringAsync("/api/users?page=2");
			var httpbinHttpclient = httpClientFactory.CreateClient("httpbin");
			var httpbinResult = await httpbinHttpclient.GetStringAsync("/get");

			return Json(new { reqresResult = reqresResult, httpbinResult = httpbinResult});
		}
    }
}
