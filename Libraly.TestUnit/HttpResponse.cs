using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Libraly.TestUnit.Interfaces;
using Libraly_Test2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Libraly.TestUnit
{
    public class HttpResponse: IClassFixture<CustomWebApplicationFactory<Startup>>,IHttpResponse
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public HttpResponse(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

      


        public async Task<string> HttpPost(Object obj,string url)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //arrange
            var response = await _factory.Client.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> HttpGet(string url)
        {
            var response = await _factory.Client.GetAsync(url);
          return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> HttpDelete(string url)
        {
            var response = await _factory.Client.DeleteAsync(url);
           return await response.Content.ReadAsStringAsync();
        }

        public int JsonAnswer(string responseBody)
        {
            var jObject = JsonConvert.DeserializeObject(responseBody);
            var token = JObject.Parse(jObject.ToString());
            return int.Parse(token["CodeStatus"].ToString());
        }
   
    }
}