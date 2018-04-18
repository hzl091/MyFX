using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyFX.Core.BaseModel.Result;
using MyFX.WebApi.Test.Filters;
using Newtonsoft.Json;

namespace MyFX.WebApi.Test.Controllers
{
    public class OrderController : ApiController
    {
        //[OmsJwtAuthentication]
        public OrderResult Get(string orderno)
        {
            var order = new Order();
            order.OrderNo = "445454656565";
            order.Total = 10000;

            var rs = new OrderResult();
            rs.Wecome = "hello";
            rs.DataBody = order;
            return rs;
        }
    }


    public class OrderResult : ResultObject<Order>
    {
        public string Wecome { get; set; }
    }

    public class Order
    {
        [JsonProperty(PropertyName = "orderNo")]
        public string OrderNo { get; set; }
        public decimal Total { get; set; }
    }
}
