using System.Security.Principal;

namespace MyFX.Core.Security
{
    /// <summary>
    /// 用户标识
    /// </summary>
    public class Identity : IIdentity
    {
        private readonly UserInfo _userInfo;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public Identity(UserInfo userInfo)
        {
            _userInfo = userInfo;
        }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int Id
        {
            get { return _userInfo.UserId; }
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name
        {
            get { return _userInfo.UserName; }
        }

        /// <summary>
        /// 身份认证类型
        /// </summary>
        public string AuthenticationType
        {
            get { return "custom"; }
        }

        /// <summary>
        /// 是否通过身份认证
        /// </summary>
        public bool IsAuthenticated
        {
            get { return true; }
        }
    }
}