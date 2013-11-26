using System;
using System.Collections.Generic;
using System.Text;

namespace Http
{
    /// <summary> 
    /// 上传数据参数 
    /// </summary> 
    public class UploadEventArgs : EventArgs
    {
        int bytesSent;
        int totalBytes;
        /// <summary> 
        /// 已发送的字节数 
        /// </summary> 
        public int BytesSent
        {
            get { return bytesSent; }
            set { bytesSent = value; }
        }
        /// <summary> 
        /// 总字节数 
        /// </summary> 
        public int TotalBytes
        {
            get { return totalBytes; }
            set { totalBytes = value; }
        }
    } 
}
