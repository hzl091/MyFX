using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.DataAnnotations;

namespace MyFX.WebApiClinetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> s = TestAsync();
            Console.WriteLine(s.Result);
            Console.ReadKey();
        }

        static async Task<string> TestAsync()
        {
            var client = HttpApiClient.Create<IMyWebApi>();
            var news = await client.GetNews(7);
            return news;
        }
    }

    //https://news.cnblogs.com/NewsAjax/GetRecentNews?itemCount=7
    [HttpHost("https://news.cnblogs.com")]
    public interface IMyWebApi : IHttpApiClient
    {
        // GET webapi/user?account=laojiu
        // Return 原始string内容
        [HttpGet("/NewsAjax/GetRecentNews")]
        ITask<string> GetNews(int itemCount);
    }
}
