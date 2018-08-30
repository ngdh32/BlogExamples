using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IHttpClientDemo.Controllers
{
    public class TypedController : Controller
    {
		public ReqresHttpClient client { get; set; }

		public TypedController(ReqresHttpClient client){
			this.client = client;
		}

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


		public async Task<IActionResult> Test(){
			var reqresResult = await client.GetResult();

            return Json(new { reqresResult = reqresResult });
		}
    }
}
