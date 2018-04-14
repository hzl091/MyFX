using System.Web;
using MyFX.Core.Contexts;

namespace MyFX.Core
{
    /// <summary>
    /// 调用上下文
    /// </summary>
    public static class InvokeContext {
        /// <summary>
        /// 初始化上下文
        /// </summary>
        static InvokeContext() {
            if( IsWeb )
                _context = new WebContext();
            else 
                _context = new WindowsContext();
        }

        /// <summary>
        /// 上下文
        /// </summary>
        private static readonly IContext _context;

        /// <summary>
        /// 是否Web系统
        /// </summary>
        public static bool IsWeb {
            get { return HttpContext.Current != null; }
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">对象</param>
        public static void Add<T>( string key, T value ) {
            _context.Add( key,value );
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        public static T Get<T>( string key ) {
            return _context.Get<T>( key );
        }

        /// <summary>
        /// 移除对象
        /// </summary>
        /// <param name="key">键名</param>
        public static void Remove( string key ) {
            _context.Remove( key );
        }
    }
}
