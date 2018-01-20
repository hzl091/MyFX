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
        int retStatus { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        string retMsg { get; set; }

        /// <summary>
        /// 异常时返回的业务数据
        /// </summary>
        object retErrorBody { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        bool isOk { get; set; }
    }
}
