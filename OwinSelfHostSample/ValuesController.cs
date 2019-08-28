//using Newtonsoft.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OwinSelfHostSample
{
    //[EnableCors(origins: "*", headers: "*", methods: "GET,POST")]
    public class ValuesController : ApiController
    {
        static HttpClient client = new HttpClient();
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/Values/GetAsync")]
        [HttpGet]
        public async Task<string> GetAsync()
        {
            string response = await GetStringAsync();
            return response;
        }

        [Route("api/Values/GetAsync2")]
        [HttpGet]
        public async Task<string> GetAsync2()
        {
            string response = await GetStringAsync2();
            return response;
        }

        // GET api/values/5 
        public IHttpActionResult Get(int id)
        {
            if (id != 5)
            {
                return BadRequest();
            }
            return Ok("value");
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
        static async Task<string> GetStringAsync()
        {
            var title = "";
            var name = "";
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("3. Awaiting the result of GetStringAsync of Http Client...");
            var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/1");
            JObject json = JObject.Parse(result);
            title = json.SelectToken("title").ToString();
            Console.WriteLine(title);

            try
            {
                var result2 = await client.GetStringAsync("https://jsonplaceholder.typicode.com/comments");
                //result2 = "{'arrayJ': " + result2 + "}"; array--> json
                var json2 = JArray.Parse(result2);
                name = json2.SelectToken("[0].name").ToString();
                Console.WriteLine(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            sw.Stop();

            //Console.WriteLine("Time taken: {0}s", sw.Elapsed.TotalSeconds/*TotalMilliseconds*/);
            var JsonResult = "{'title': '" + title + "', 'name': '" + name + "', 'Time Taken': '" + sw.Elapsed.TotalSeconds + "s'}";
            Console.WriteLine(JsonResult);

            return JsonResult;
        }

        static async Task<string> GetStringAsync2()
        {
            var title = "";
            var name = "";
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("3. Awaiting the result of GetStringAsync of Http Client...");
            var result = client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/1");
            
            var result2 = client.GetStringAsync("https://jsonplaceholder.typicode.com/comments");
            //result2 = "{'arrayJ': " + result2 + "}"; array--> json
            
            var end = await Task<string>.WhenAll(result, result2);

            JObject json = JObject.Parse(result.Result);
            title = json.SelectToken("title").ToString();
            Console.WriteLine(title);

            var json2 = JArray.Parse(result2.Result);
            name = json2.SelectToken("[0].name").ToString();
            Console.WriteLine(name);

            sw.Stop();

            //Console.WriteLine("Time taken: {0}s", sw.Elapsed.TotalSeconds/*TotalMilliseconds*/);
            var JsonResult = "{'title': '" + title + "', 'name': '" + name + "', 'Time Taken': '" + sw.Elapsed.TotalSeconds + "s'}";
            Console.WriteLine(JsonResult);

            return JsonResult;
        }

    }
}
