using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MyFX.Core.Base
{
    /// <summary>
    /// 实现支持JSON序列化的扩展方法。
    /// </summary>
    /// <remarks>
    /// 目前内部使用 DataContractJsonSerializer 进行JSON 序列化。
    /// </remarks>
    public static class JsonSerializerExtension
    {
        #region 序列化

        /// <summary>
        /// 将指定对象序列化为Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToJson<T>(this T obj)
        {
            return SerializeToJson(obj, typeof(T));
        }

        /// <summary>
        /// 将指定对象序列化为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToJson(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            return SerializeToJson(obj, obj.GetType());
        }

        static string SerializeToJson(this object obj, Type objType)
        {
            StringBuilder sb = new StringBuilder();
            DataContractJsonSerializer xs = new DataContractJsonSerializer(objType);
            MemoryStream stream = new MemoryStream();
            xs.WriteObject(stream, obj);
            stream.Flush();
            stream.Position = 0;
            TextReader tr = new StreamReader(stream);
            return tr.ReadToEnd();
        }

        /// <summary>
        /// 将指定对象序列化到指定文件上
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        public static void SerializeToJsonFile<T>(this T obj, string filePath)
        {
            SerializeToJsonFile(obj, typeof(T), filePath);
        }

        /// <summary>
        /// 将指定对象序列化到指定文件上
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        public static void SerializeToJsonFile(this object obj, string filePath)
        {
            if (obj == null)
            {
                return;
            }
            SerializeToJsonFile(obj, obj.GetType(), filePath);
        }

        static void SerializeToJsonFile(this object obj, Type objType, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer xs = new DataContractJsonSerializer(objType);
                xs.WriteObject(fs, obj);
                fs.Flush();
            }
        }

        #endregion

        #region 反序列化

        /// <summary>
        /// 从指定Json反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeserializeFromJson<T>(this string json)
        {
            return (T)DeserializeFromJson(json, typeof(T));
        }

        /// <summary>
        /// 从指定Json反序列化对象
        /// </summary>
        /// <param name="json"></param>
        /// <param name="objType"></param>
        /// <returns></returns>
        public static object DeserializeFromJson(this string json, Type objType)
        {
            if (json == null)
            {
                return null;
            }

            DataContractJsonSerializer xs = new DataContractJsonSerializer(objType);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            MemoryStream ms = new MemoryStream(bytes);
            return xs.ReadObject(ms);
        }

        /// <summary>
        /// 从指定文件反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromJsonFile<T>(this string filePath)
        {
            return (T)DeserializeFromJsonFile(filePath, typeof(T));
        }

        /// <summary>
        /// 从指定文件反序列化对象
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="objType"></param>
        /// <returns></returns>
        public static object DeserializeFromJsonFile(this string filePath, Type objType)
        {
            using (Stream fs = new FileStream(filePath, FileMode.Open))
            {
                DataContractJsonSerializer xs = new DataContractJsonSerializer(objType);
                return xs.ReadObject(fs);
            }
        }

        /// <summary>
        /// 从指定流反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T DeserializeFromJson<T>(this Stream stream)
        {
            return (T)DeserializeFromJson(stream, typeof(T));
        }

        /// <summary>
        /// 从指定流反序列化对象
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="objType"></param>
        /// <returns></returns>
        public static object DeserializeFromJson(this Stream stream, Type objType)
        {
            DataContractJsonSerializer xs = new DataContractJsonSerializer(objType);
            return xs.ReadObject(stream);
        }

        #endregion
    }
}
