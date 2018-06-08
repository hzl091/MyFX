using System.Security.Principal;

namespace MyFX.Core.Security
{
    /// <summary>
    /// 客户主体
    /// </summary>
    public class Principal : IPrincipal
    {
        private readonly Identity _identity;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="identity">用户标识信息</param>
        public Principal(Identity identity)
        {
            _identity = identity;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public IIdentity Identity
        {
            get { return _identity; }
        }

        /// <summary>
        /// 是否属于某个角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string role) { return false; }
    }
}