/****************************************************************************************
 * 文件名：FileHelper
 * 作者：huangzl
 * 创始时间：2017/10/12 11:06:41
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyFX.Core.Base
{
    /// <summary>
    /// 文件及流操作助手类
    /// </summary>
    public partial class FileHelper
    {

        #region Read(读取文件到字符串)

        /// <summary>
        /// 读取文件到字符串
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static string Read(string filePath)
        {
            return Read(filePath, Encoding.GetEncoding("utf-8"));
        }

        /// <summary>
        /// 读取文件到字符串
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="encoding">字符编码</param>
        public static string Read(string filePath, Encoding encoding)
        {
            if (!System.IO.File.Exists(filePath))
                return string.Empty;
            using (var reader = new StreamReader(filePath, encoding))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion

        #region ReadToBytes(将文件读取到字节流中)

        /// <summary>
        /// 将文件读取到字节流中
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static byte[] ReadToBytes(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                return null;
            FileInfo fileInfo = new FileInfo(filePath);
            int fileSize = (int)fileInfo.Length;
            using (BinaryReader reader = new BinaryReader(fileInfo.Open(FileMode.Open)))
            {
                return reader.ReadBytes(fileSize);
            }
        }

        #endregion

        #region Write(将字节流写入文件)

        /// <summary>
        /// 将字节流写入文件,文件不存在则创建
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="bytes">数据</param>
        public static void Write(string filePath, byte[] bytes)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return;
            if (bytes == null)
                return;
            FileInfo file = new FileInfo(filePath);
            using (FileStream fileStream = file.Open(FileMode.OpenOrCreate))
            {
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }

        #endregion

        #region Delete(删除文件)

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static void Delete(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return;
            System.IO.File.Delete(filePath);
        }

        #endregion

        #region GetAllFiles(获取目录中全部文件列表)

        /// <summary>
        /// 获取目录中全部文件列表，包括子目录
        /// </summary>
        /// <param name="directoryPath">目录绝对路径</param>
        public static List<string> GetAllFiles(string directoryPath)
        {
            return Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories).ToList();
        }

        #endregion

        /// <summary>
        /// 从文件路径中获取目录路径
        /// </summary>
        /// <param name="filePath">文件路径,可以是绝对路径，也可以是相对路径</param>
        public static string GetDirectoryFromPath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return string.Empty;
            filePath = filePath.Replace("/", "\\");
            int lastIndex = filePath.LastIndexOf("\\", StringComparison.Ordinal);
            return filePath.Substring(0, lastIndex + 1);
        }

        /// <summary>
        /// 连接基路径和子路径,比如把 c: 与 test.doc 连接成 c:\test.doc
        /// </summary>
        /// <param name="basePath">基路径,范例：c:</param>
        /// <param name="subPath">子路径,可以是文件名, 范例：test.doc</param>
        public static string JoinPath(string basePath, string subPath)
        {
            basePath = basePath.TrimEnd('/').TrimEnd('\\');
            subPath = subPath.TrimStart('/').TrimStart('\\');
            string path = basePath + "\\" + subPath;
            return path.Replace("/", "\\").ToLower();
        }

        #region 数据流操作
        /// <summary>
        /// 流转换成字符串
        /// </summary>
        /// <param name="data">数据</param>
        public static string StreamToString(Stream data)
        {
            return StreamToString(data, Encoding.GetEncoding("utf-8"));
        }

        /// <summary>
        /// 流转换成字符串
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="encoding">字符编码</param>
        public static string StreamToString(Stream data, Encoding encoding)
        {
            if (data == null)
                return String.Empty;
            string result;
            using (var reader = new StreamReader(data, encoding))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// 字符串转换成流
        /// </summary>
        /// <param name="data">数据</param>
        public static Stream StringToStream(string data)
        {
            return StringToStream(data, Encoding.GetEncoding("utf-8"));
        }

        /// <summary>
        /// 字符串转换成流
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="encoding">字符编码</param>
        public static Stream StringToStream(string data, Encoding encoding)
        {
            if (String.IsNullOrWhiteSpace(data))
                return Stream.Null;
            return new MemoryStream(StringToBytes(data, encoding));
        }

        /// <summary>
        /// 字符串转换成字节数组
        /// </summary>
        /// <param name="data">数据,默认字符编码utf-8</param>        
        public static byte[] StringToBytes(string data)
        {
            return StringToBytes(data, Encoding.GetEncoding("utf-8"));
        }

        /// <summary>
        /// 字符串转换成字节数组
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="encoding">字符编码</param>
        public static byte[] StringToBytes(string data, Encoding encoding)
        {
            if (string.IsNullOrWhiteSpace(data))
                return new byte[] { };
            return encoding.GetBytes(data);
        }

        /// <summary>
        /// 字节数组转换成字符串
        /// </summary>
        /// <param name="data">数据,默认字符编码utf-8</param>        
        public static string BytesToString(byte[] data)
        {
            return BytesToString(data, Encoding.GetEncoding("utf-8"));
        }

        /// <summary>
        /// 字节数组转换成字符串
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="encoding">字符编码</param>
        public static string BytesToString(byte[] data, Encoding encoding)
        {
            if (data == null || data.Length == 0)
                return string.Empty;
            return encoding.GetString(data);
        }

        /// <summary>
        /// 字节数组转换成整数
        /// </summary>
        /// <param name="data">数据</param>
        public static int BytesToInt(byte[] data)
        {
            if (data == null || data.Length < 4)
                return 0;
            var buffer = new byte[4];
            Buffer.BlockCopy(data, 0, buffer, 0, 4);
            return BitConverter.ToInt32(buffer, 0);
        }

        /// <summary>
        /// 流转换为字节流
        /// </summary>
        /// <param name="stream">流</param>
        public static byte[] StreamToBytes(Stream stream)
        {
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return buffer;
        }
        #endregion
    }
}
