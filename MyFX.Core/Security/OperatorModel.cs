using System;

namespace MyFX.Core.Security
{
    /// <summary>
    /// 操作人
    /// </summary>
    public class OperatorModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DepartmentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LoginIpAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LoginIpAddressName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LoginToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSystem { get; set; }
    }
}
