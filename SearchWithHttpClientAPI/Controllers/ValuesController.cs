using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SearchWithHttpClientAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public async void Get()
        {
            string page = "http://www.google.com.au/search?q=online+Title+Search";

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();

                Console.WriteLine(result);
            }
            
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        static async void DownloadPageAsync()
        {
            string page = "http://www.google.com/search?q=TestKeyword";

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();

                Console.WriteLine(result);
            }
        }
    }
}
