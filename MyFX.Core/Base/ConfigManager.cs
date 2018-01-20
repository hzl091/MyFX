using System;
using System.Configuration;

namespace MyFX.Core.Base
{
    /// <summary>
    /// 配置管理助手类
    /// </summary>
    public static class ConfigManager
    {
        #region connection string

        /// <summary>
        /// 从当前应用程序配置文件中读取指定连接字符串。如果未找到，则抛出异常。
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ConfigurationErrorsException">如果未找到</exception>
        /// <returns></returns>
        public static string GetConnectionString(string name)
        {
            return GetConnectionString(name, true);
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定连接字符串。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="throwsIfNotFound">指示未找到时是否抛出异常。</param>
        /// <exception cref="ConfigurationErrorsException">如果未找到</exception>
        /// <returns></returns>
        public static string GetConnectionString(string name, bool throwsIfNotFound)
        {
            ConnectionStringSettings connStrSettings = ConfigurationManager.ConnectionStrings[name];
            if (connStrSettings == null)
            {
                if (throwsIfNotFound)
                {
                    throw new ConfigurationErrorsException(string.Format("未找到:{0}",name));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return connStrSettings.ConnectionString;
            }
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定连接字符串。如果未找到，则返回指定缺省连接字符串<paramref name="defaultConnectionString"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultConnectionString"></param>
        /// <returns></returns>
        public static string GetConnectionString(string name, string defaultConnectionString)
        {
            ConnectionStringSettings connStrSettings = ConfigurationManager.ConnectionStrings[name];
            if (connStrSettings == null)
            {
                return defaultConnectionString;
            }
            return connStrSettings.ConnectionString;
        }

        /// <summary>
        /// 从指定连接字符串配置集合中读取指定连接字符串。
        /// </summary>
        /// <param name="connectionStringSettingsCollection"></param>
        /// <param name="name"></param>
        /// <param name="throwsIfNotFound"></param>
        /// <returns></returns>
        public static string GetConnectionString(this ConnectionStringSettingsCollection connectionStringSettingsCollection,
            string name, bool throwsIfNotFound)
        {
            ConnectionStringSettings connStrSettings = connectionStringSettingsCollection[name];
            if (connStrSettings == null)
            {
                if (throwsIfNotFound)
                {
                    throw new ConfigurationErrorsException(string.Format("未找到:{0}", name));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return connStrSettings.ConnectionString;
            }
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定连接字符串配置元素。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="throwsIfNotFound">指示未找到时是否抛出异常。</param>
        /// <exception cref="ConfigurationErrorsException">如果未找到</exception>
        /// <returns></returns>
        public static ConnectionStringSettings GetConnectionStringSettings(string name, bool throwsIfNotFound)
        {
            ConnectionStringSettings connStrSettings = ConfigurationManager.ConnectionStrings[name];
            if (connStrSettings == null && throwsIfNotFound)
            {
                throw new ConfigurationErrorsException(string.Format("未找到:{0}", name));
            }
            return connStrSettings;
        }

        /// <summary>
        /// 从指定连接字符串配置集合中读取指定连接字符串配置元素。
        /// </summary>
        /// <param name="connectionStringSettingsCollection"></param>
        /// <param name="name"></param>
        /// <param name="throwsIfNotFound"></param>
        /// <returns></returns>
        public static ConnectionStringSettings GetConnectionStringSettings(this ConnectionStringSettingsCollection connectionStringSettingsCollection,
            string name, bool throwsIfNotFound)
        {
            ConnectionStringSettings connStrSettings = connectionStringSettingsCollection[name];
            if (connStrSettings == null && throwsIfNotFound)
            {
                throw new ConfigurationErrorsException(string.Format("未找到:{0}", name));
            }
            return connStrSettings;
        }

        #endregion

        #region app settings

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，则返回 null。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetAppSetting(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="throwsIfNotFound">指示未找到时是否抛出异常。</param>
        /// <exception cref="ConfigurationErrorsException">如果未找到</exception>
        /// <returns></returns>
        public static string GetAppSetting(string name, bool throwsIfNotFound)
        {
            string value = ConfigurationManager.AppSettings[name];
            if (value == null && throwsIfNotFound)
            {
                throw new ConfigurationErrorsException(string.Format("未找到:{0}", name));
            }
            return value;
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，则返回指定的缺省值<paramref name="defaultValue"/>。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetAppSetting(string name, string defaultValue)
        {
            string value = ConfigurationManager.AppSettings[name];
            if (value == null)
            {
                return defaultValue;
            }
            return value;
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，抛出异常。
        /// </summary>
        /// <param name="name"></param>        
        /// <exception cref="ConfigurationErrorsException">如果未找到时</exception>
        /// <returns></returns>
        public static bool GetAppSettingAsBoolean(string name)
        {
            string value = GetAppSetting(name, true);
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Invalid value for appSettings[{0}]".FormatString(name), ex);
            }
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，则返回指定的缺省值<paramref name="defaultValue"/>。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool GetAppSettingAsBoolean(string name, bool defaultValue)
        {
            string value = ConfigurationManager.AppSettings[name];
            if (value == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Invalid value for appSettings[{0}]".FormatString(name), ex);
            }
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，抛出异常。
        /// </summary>
        /// <param name="name"></param>        
        /// <exception cref="ConfigurationErrorsException">如果未找到时</exception>
        /// <returns></returns>
        public static double GetAppSettingAsDouble(string name)
        {
            string value = GetAppSetting(name, true);
            try
            {
                return Convert.ToDouble(value);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Invalid value for appSettings[{0}]".FormatString(name), ex);
            }
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，则返回指定的缺省值<paramref name="defaultValue"/>。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double GetAppSettingAsDouble(string name, double defaultValue)
        {
            string value = ConfigurationManager.AppSettings[name];
            if (value == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToDouble(value);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Invalid value for appSettings[{0}]".FormatString(name), ex);
            }
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，抛出异常。
        /// </summary>
        /// <param name="name"></param>        
        /// <exception cref="ConfigurationErrorsException">如果未找到时</exception>
        /// <returns></returns>
        public static int GetAppSettingAsInt32(string name)
        {
            string value = GetAppSetting(name, true);
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Invalid value for appSettings[{0}]".FormatString(name), ex);
            }
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，则返回指定的缺省值<paramref name="defaultValue"/>。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetAppSettingAsInt32(string name, int defaultValue)
        {
            string value = ConfigurationManager.AppSettings[name];
            if (value == null)
            {
                return defaultValue;
            }
    
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Invalid value for appSettings[{0}]".FormatString(name), ex);
            }
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，抛出异常。
        /// </summary>
        /// <param name="name"></param>        
        /// <exception cref="ConfigurationErrorsException">如果未找到时</exception>
        /// <returns></returns>
        public static TimeSpan GetAppSettingAsTimeSpan(string name)
        {
            string value = GetAppSetting(name, true);
          
            try
            {
                return TimeSpan.Parse(value);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Invalid value for appSettings[{0}]".FormatString(name), ex);
            }
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，则返回指定的缺省值<paramref name="defaultValue"/>。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TimeSpan GetAppSettingAsTimeSpan(string name, TimeSpan defaultValue)
        {
            string value = ConfigurationManager.AppSettings[name];
            if (value == null)
            {
                return defaultValue;
            }
            
            try
            {
                return TimeSpan.Parse(value);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Invalid value for appSettings[{0}]".FormatString(name), ex);
            }
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，抛出异常。
        /// </summary>
        /// <param name="name"></param>        
        /// <exception cref="ConfigurationErrorsException">如果未找到时</exception>
        /// <returns></returns>
        public static DateTime GetAppSettingAsDateTime(string name)
        {
            return GetAppSetting<DateTime>(name, DateTime.Parse);
        }

        /// <summary>
        /// 从当前应用程序配置文件中读取指定配置值。如果未找到，则返回指定的缺省值<paramref name="defaultValue"/>。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime GetAppSettingAsDateTime(string name, DateTime defaultValue)
        {
            return GetAppSetting<DateTime>(name, DateTime.Parse, defaultValue);
        }

        /// <summary>
        /// 从当前应用程序配置文件中使用指定解析器<paramref name="parser"/>解析指定配置值为<typeparamref name="TResult"/>类型。
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="name"></param>
        /// <param name="parser"></param>
        /// <returns></returns>
        public static TResult GetAppSetting<TResult>(string name, Func<string, TResult> parser)
        {
            TResult result;
            if (!GetAppSetting(name, parser, out result))
            {
                throw new ConfigurationErrorsException(string.Format("未找到:{0}", name));
            }
            return result;
        }

        /// <summary>
        /// 从当前应用程序配置文件中使用指定解析器<paramref name="parser"/>解析指定配置值为<typeparamref name="TResult"/>类型。
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="name"></param>
        /// <param name="parser"></param>
        /// <param name="defaultValue">用于未找到指定配置的缺省值。</param>
        /// <returns></returns>
        public static TResult GetAppSetting<TResult>(string name, Func<string, TResult> parser, TResult defaultValue)
        {
            TResult result;
            if (!GetAppSetting(name, parser, out result))
            {
                result = defaultValue;
            }
            return result;
        }

        /// <summary>
        /// 从当前应用程序配置文件中使用指定解析器<paramref name="parser"/>解析指定配置值为<typeparamref name="TResult"/>类型。        
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="name"></param>
        /// <param name="parser"></param>
        /// <param name="result"></param>
        /// <returns>如果找到，则返回>true，否则返回false。</returns>
        public static bool GetAppSetting<TResult>(string name, Func<string, TResult> parser, out TResult result)
        {
            result = default(TResult);
            string value = ConfigurationManager.AppSettings[name];
            if (value != null)
            {
                try
                {
                    result = parser(value);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new ConfigurationErrorsException("Invalid value for appSettings[{0}]".FormatString(name), ex);
                }
            }
            return false;
        }

        #endregion
    }
}
