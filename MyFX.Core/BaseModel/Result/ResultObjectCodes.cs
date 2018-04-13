/****************************************************************************************
 * 文件名：ResultObjectCodes
 * 作者：huangzl
 * 创始时间：2017/10/16 17:15:29
 * 创建说明：
****************************************************************************************/

namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// 结果代码
    /// </summary>
    public class ResultObjectCodes
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        public static readonly int Success = 200;

        /// <summary>
        /// 验证失败
        /// </summary>
        public static readonly int ValidateFailed = 400;

        /// <summary>
        /// 未授权
        /// </summary>
        public static readonly int Unauthorized = 401;

        /// <summary>
        /// 操作被禁止
        /// </summary>
        public static readonly int OperationForbidden = 403;

        /// <summary>
        /// 资源未找到
        /// </summary>
        public static readonly int NoFound = 404;

        /// <summary>
        /// 数据并发冲突
        /// </summary>
        public static readonly int DbUpdateConcurrency = 408;

        /// <summary>
        /// 服务器内部错误
        /// </summary>
        public static readonly int ServerError = 500;
    }
}
