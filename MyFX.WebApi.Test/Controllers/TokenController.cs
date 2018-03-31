using System.Net;
using System.Web.Http;
using MyFX.WebApi.Extension;

namespace MyFX.WebApi.Test.Controllers
{
    public class TokenController : ApiController
    {
        // THis is naive endpoint for demo, it should use Basic authentication to provide token or POST request
        [AllowAnonymous]
        public string Get(string username, string password)
        {
            if (CheckUser(username, password))
            {
                return JwtManager.GenerateToken(username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        public bool CheckUser(string username, string password)
        {
            // should check in the database
            return true;
        }
    }
}

//claimsIdentity https://www.cnblogs.com/dudu/p/6367303.html    https://www.cnblogs.com/freeliver54/p/6256491.html
//swagger启用header支持  https://www.cnblogs.com/dukang1991/p/5627673.html

//********  httpclient调用实例 ***********
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.AccessControl;
//using System.Text;
//using System.Threading.Tasks;
//using RestSharp;

//namespace jwtClientDemo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var client = new RestClient("http://www.jwttest.com/api/");
//            var request = new RestRequest("token");
//            request.AddQueryParameter("username", "aaa");
//            request.AddQueryParameter("password", "bbb");

//            var res = client.Execute(request);
//            string token = res.Content;
//            Console.WriteLine(token);


//            var request1 = new RestRequest("value", Method.GET);
//            string t = string.Format("Bearer {0}", token);
//            Console.WriteLine(t);


//            request1.AddHeader("Authorization", t.Replace("\"",""));
//            var res1 = client.Execute(request1);
//            Console.WriteLine(res1.Content);
//            Console.ReadKey();
//        }
//    }
//}
