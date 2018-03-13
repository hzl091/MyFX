using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFX.WebApi.Extension.Filters;

namespace MyFX.WebApi.Test.Filters
{
    public class OmsJwtAuthenticationAttribute : JwtAuthenticationAttribute
    {
        protected override bool CheckUserExists(string username)
        {
            return true;
            //查数据库或者服务确认用户是否存在
        }
    }
}