namespace MyFX.Core.Security
{
    /// <summary>
    /// 请求签名头
    /// </summary>
    public class SignatureHeader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">应用系统代码</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <param name="signature">签名</param>
        public SignatureHeader(string appid, string timestamp, string nonce, string signature)
        {
            AppId = appid;
            Timestamp =timestamp;
            Nonce = nonce;
            Signature = signature;
        }
        /// <summary>
        /// 应用系统代码
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 检验参数
        /// </summary>
        /// <returns></returns>
        public bool Verify()
        {
            if (string.IsNullOrEmpty(AppId)
                || string.IsNullOrEmpty(Timestamp)
                || string.IsNullOrEmpty(Nonce)
                || string.IsNullOrEmpty(Signature))
                return false;
            return true;
        }

        public override string ToString()
        {
            return AppId + Timestamp + Nonce;
        }
    }
}
