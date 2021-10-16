using System;
using System.Threading.Tasks;

namespace Libraly.TestUnit.Interfaces
{
    public interface IHttpResponse
    {
        Task<string> HttpPost(Object obj,string url);
        Task<string> HttpGet(string url);
        Task<string> HttpDelete(string url);
        int JsonAnswer(string responseBody);
    }
}