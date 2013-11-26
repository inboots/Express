using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Http
{
   /// <summary> 
    /// 对文件和文本数据进行Multipart形式的编码 
    /// </summary> 
    public class MultipartForm 
    { 
        private Encoding encoding; 
        private MemoryStream ms; 
        private string boundary; 
        private byte[] formData; 
        /// <summary> 
        /// 获取编码后的字节数组 
        /// </summary> 
        public byte[] FormData 
        { 
            get 
            { 
                if (formData == null) 
                { 
                    byte[] buffer = encoding.GetBytes("--" + this.boundary + "--\r\n"); 
                    ms.Write(buffer, 0, buffer.Length); 
                    formData = ms.ToArray(); 
                } 
                return formData; 
            } 
        } 
        /// <summary> 
        /// 获取此编码内容的类型 
        /// </summary> 
        public string ContentType 
        { 
            get { return string.Format("multipart/form-data; boundary={0}", this.boundary); } 
        } 
        /// <summary> 
        /// 获取或设置对字符串采用的编码类型 
        /// </summary> 
        public Encoding StringEncoding 
        { 
            set { encoding = value; } 
            get { return encoding; } 
        } 
        /// <summary> 
        /// 实例化 
        /// </summary> 
        public MultipartForm() 
        { 
            boundary = string.Format("--{0}--", Guid.NewGuid()); 
            ms = new MemoryStream(); 
            encoding = Encoding.Default; 
        } 
        /// <summary> 
        /// 添加一个文件 
        /// </summary> 
        /// <param name="name">文件域名称</param> 
        /// <param name="filename">文件的完整路径</param> 
        public void AddFlie(string name, string filename) 
        { 
            if (!File.Exists(filename)) 
                throw new FileNotFoundException("尝试添加不存在的文件。", filename); 
            FileStream fs = null; 
            byte[] fileData ={ }; 
            try 
            { 
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read); 
                fileData = new byte[fs.Length]; 
                fs.Read(fileData, 0, fileData.Length); 
                this.AddFlie(name, Path.GetFileName(filename), fileData, fileData.Length); 
            } 
            catch (Exception) 
            { 
                throw; 
            } 
            finally 
            { 
                if (fs != null) fs.Close(); 
            } 
        } 
        /// <summary> 
        /// 添加一个文件 
        /// </summary> 
        /// <param name="name">文件域名称</param> 
        /// <param name="filename">文件名</param> 
        /// <param name="fileData">文件二进制数据</param> 
        /// <param name="dataLength">二进制数据大小</param> 
        public void AddFlie(string name, string filename, byte[] fileData, int dataLength) 
        { 
            if (dataLength <= 0 || dataLength > fileData.Length) 
            { 
                dataLength = fileData.Length; 
            } 
            StringBuilder sb = new StringBuilder(); 
            sb.AppendFormat("--{0}\r\n", this.boundary); 
            sb.AppendFormat("Content-Disposition: form-data; name=\"{0}\";filename=\"{1}\"\r\n", name, filename); 
            sb.AppendFormat("Content-Type: {0}\r\n", this.GetContentType(filename)); 
            sb.Append("\r\n"); 
            byte[] buf = encoding.GetBytes(sb.ToString()); 
            ms.Write(buf, 0, buf.Length); 
            ms.Write(fileData, 0, dataLength); 
            byte[] crlf = encoding.GetBytes("\r\n"); 
            ms.Write(crlf, 0, crlf.Length); 
        } 
        /// <summary> 
        /// 添加字符串 
        /// </summary> 
        /// <param name="name">文本域名称</param> 
        /// <param name="value">文本值</param> 
        public void AddString(string name, string value) 
        { 
            StringBuilder sb = new StringBuilder(); 
            sb.AppendFormat("--{0}\r\n", this.boundary); 
            sb.AppendFormat("Content-Disposition: form-data; name=\"{0}\"\r\n", name); 
            sb.Append("\r\n"); 
            sb.AppendFormat("{0}\r\n", value); 
            byte[] buf = encoding.GetBytes(sb.ToString()); 
            ms.Write(buf, 0, buf.Length); 
        } 
        /// <summary> 
        /// 从注册表获取文件类型 
        /// </summary> 
        /// <param name="filename">包含扩展名的文件名</param> 
        /// <returns>如：application/stream</returns> 
        private string GetContentType(string filename) 
        { 
            Microsoft.Win32.RegistryKey fileExtKey = null; ; 
            string contentType = "application/stream"; 
            try 
            { 
                fileExtKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(Path.GetExtension(filename)); 
                contentType = fileExtKey.GetValue("Content Type", contentType).ToString(); 
            } 
            finally 
            { 
                if (fileExtKey != null) fileExtKey.Close(); 
            } 
            return contentType; 
        } 
    } 
}

