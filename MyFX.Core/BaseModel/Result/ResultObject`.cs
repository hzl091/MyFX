namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// 相应信息包装类
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public class ResultObject<TResponse> : ResultObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ResultObject()
            : base()
        {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="retBody">要返回的业务数据</param>
        public ResultObject(TResponse retBody) :
            this()
        {
           this.retBody = retBody;
        }

        /// <summary>
        /// 返回的业务数据
        /// </summary>
        //[DataMember]
        public TResponse retBody { get; set; }

    }
}
