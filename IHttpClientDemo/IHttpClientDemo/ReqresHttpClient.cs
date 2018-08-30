using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IHttpClientDemo
{
    public class ReqresHttpClient
    {
		public HttpClient client { get; set; }

        public ReqresHttpClient(HttpClient client)
        {
			client.BaseAddress = new Uri("https://reqres.in/");
			this.client = client;
        }
        
		public async Task<string> GetResult()
        {
            var reqresResult = await client.GetStringAsync("/api/users?page=2");

			return reqresResult;
        }
    }
}
