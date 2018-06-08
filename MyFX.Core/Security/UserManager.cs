using System.Web;
using MyFX.Core.Exceptions;

namespace MyFX.Core.Security
{
    public class UserManager
    {
        public static UserInfo GetCurrentUser()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                throw new MyFXException("获取当前用户信息失败");
            }

            var customerInfo = HttpContext.Current.User as Principal;
            if (customerInfo == null)
            {
                throw new MyFXException("获取当前用户信息失败");
            }
            else
            {
                var identity = customerInfo.Identity as Identity;
                return new UserInfo() {
                    UserId = identity.Id,
                    UserName = identity.Name
                };
            }
        }
    }
}