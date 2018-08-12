using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFX.Core.BaseModel.Result
{
    public interface IResultObject
    {
        /// <summary>
        /// 状态码
        /// </summary>
        int Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// 异常时返回的业务数据
        /// </summary>
        object ErrorInfo { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        bool IsOk { get; set; }
    }
}
