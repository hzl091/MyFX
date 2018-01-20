namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// ResultObjec扩展
    /// </summary>
    public static class ResultObjectExtension
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resultObject"></param>
        /// <returns></returns>
        public static T To<T>(this ResultObject resultObject) where T : ResultObject ,new()
        {
            if (resultObject == null) { return null; }
            T obj = new T
            {
                retStatus = resultObject.retStatus,
                retMsg = resultObject.retMsg,
                isOk = resultObject.isOk
            };
            return obj;
        }
    }
}
