using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Net.Ftp
{
    /// <summary>
    /// FTP处理操作类
    /// 功能：
    /// 下载文件
    /// 上传文件
    /// 上传文件的进度信息
    /// 下载文件的进度信息
    /// 删除文件
    /// 列出文件
    /// 列出目录
    /// 进入子目录
    /// 退出当前目录返回上一层目录
    /// 判断远程文件是否存在
    /// 判断远程文件是否存在
    /// 删除远程文件    
    /// 建立目录
    /// 删除目录
    /// 文件（目录）改名

    /// </summary>
    /// <remarks>
    /// 创建人：南疯
    /// 创建时间：2007年4月28日
    /// </remarks>
    #region 文件信息结构
    public struct FileStruct
    {
        public string Flags;
        public string Owner;
        public string Group;
        public bool IsDirectory;
        public DateTime CreateTime;
        public string Name;
    }
    public enum FileListStyle
    {
        UnixStyle,
        WindowsStyle,
        Unknown
    }
    #endregion
    public class ClsFtp
    {
        #region 属性信息
        /// <summary>
        /// FTP请求对象
        /// </summary>
        FtpWebRequest _request;
        /// <summary>
        /// FTP响应对象
        /// </summary>
        FtpWebResponse _response;
        /// <summary>
        /// FTP服务器地址
        /// </summary>
        private Uri _uri;
        /// <summary>
        /// FTP服务器地址
        /// </summary>
        public Uri Uri
        {
            get
            {
                if (_directoryPath == "/")
                {
                    return _uri;
                }
                var strUri = _uri.ToString();
                if (strUri.EndsWith("/"))
                {
                    strUri = strUri.Substring(0, strUri.Length - 1);
                }
                return new Uri(strUri + DirectoryPath);
            }
            set
            {
                if (value.Scheme != Uri.UriSchemeFtp)
                {
                    throw new Exception("Ftp 地址格式错误!");
                }
                _uri = new Uri(value.GetLeftPart(UriPartial.Authority));
                _directoryPath = value.AbsolutePath;
                if (!_directoryPath.EndsWith("/"))
                {
                    _directoryPath += "/";
                }
            }
        }

        /// <summary>
        /// 当前工作目录
        /// </summary>
        private string _directoryPath;

        /// <summary>
        /// 当前工作目录
        /// </summary>
        public string DirectoryPath
        {
            get { return _directoryPath; }
            set { _directoryPath = value; }
        }

        /// <summary>
        /// FTP登录用户
        /// </summary>
        private string _userName;
        /// <summary>
        /// FTP登录用户
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        private string _errorMsg;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value; }
        }

        /// <summary>
        /// FTP登录密码
        /// </summary>
        private string _password;
        /// <summary>
        /// FTP登录密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// 连接FTP服务器的代理服务
        /// </summary>
        private WebProxy _proxy;
        /// <summary>
        /// 连接FTP服务器的代理服务
        /// </summary>
        public WebProxy Proxy
        {
            get
            {
                return _proxy;
            }
            set
            {
                _proxy = value;
            }
        }

        /// <summary>
        /// 是否需要删除临时文件
        /// </summary>
        private bool _isDeleteTempFile;
        /// <summary>
        /// 异步上传所临时生成的文件
        /// </summary>
        private string _uploadTempFile = "";
        #endregion
        #region 事件
        public delegate void DeDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e);
        public delegate void DeDownloadDataCompleted(object sender, AsyncCompletedEventArgs e);
        public delegate void DeUploadProgressChanged(object sender, UploadProgressChangedEventArgs e);
        public delegate void DeUploadFileCompleted(object sender, UploadFileCompletedEventArgs e);

        /// <summary>
        /// 异步下载进度发生改变触发的事件
        /// </summary>
        public event DeDownloadProgressChanged DownloadProgressChanged;
        /// <summary>
        /// 异步下载文件完成之后触发的事件
        /// </summary>
        public event DeDownloadDataCompleted DownloadDataCompleted;
        /// <summary>
        /// 异步上传进度发生改变触发的事件
        /// </summary>
        public event DeUploadProgressChanged UploadProgressChanged;
        /// <summary>
        /// 异步上传文件完成之后触发的事件
        /// </summary>
        public event DeUploadFileCompleted UploadFileCompleted;
        #endregion
        #region 构造析构函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ftpUri">FTP地址</param>
        /// <param name="strUserName">登录用户名</param>
        /// <param name="strPassword">登录密码</param>
        public ClsFtp(Uri ftpUri, string strUserName, string strPassword)
        {
            _uri = new Uri(ftpUri.GetLeftPart(UriPartial.Authority));
            _directoryPath = ftpUri.AbsolutePath;
            if (!_directoryPath.EndsWith("/"))
            {
                _directoryPath += "/";
            }
            _userName = strUserName;
            _password = strPassword;
            _proxy = null;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ftpUri">FTP地址</param>
        /// <param name="strUserName">登录用户名</param>
        /// <param name="strPassword">登录密码</param>
        /// <param name="objProxy">连接代理</param>
        public ClsFtp(Uri ftpUri, string strUserName, string strPassword, WebProxy objProxy)
        {
            _uri = new Uri(ftpUri.GetLeftPart(UriPartial.Authority));
            _directoryPath = ftpUri.AbsolutePath;
            if (!_directoryPath.EndsWith("/"))
            {
                _directoryPath += "/";
            }
            _userName = strUserName;
            _password = strPassword;
            _proxy = objProxy;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClsFtp()
        {
            _userName = "anonymous";  //匿名用户
            _password = "@anonymous";
            _uri = null;
            _proxy = null;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~ClsFtp()
        {
            if (_response != null)
            {
                _response.Close();
                _response = null;
            }
            if (_request != null)
            {
                _request.Abort();
                _request = null;
            }
        }
        #endregion
        #region 建立连接
        /// <summary>
        /// 建立FTP链接,返回响应对象
        /// </summary>
        /// <param name="uri">FTP地址</param>
        /// <param name="ftpMathod">操作命令</param>
        private FtpWebResponse Open(Uri uri, string ftpMathod)
        {
            try
            {
                _request = (FtpWebRequest) WebRequest.Create(uri);
                _request.Method = ftpMathod;
                _request.UseBinary = true;
                _request.Credentials = new NetworkCredential(UserName, Password);
                if (Proxy != null)
                {
                    _request.Proxy = Proxy;
                }
                return (FtpWebResponse) _request.GetResponse();
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 建立FTP链接,返回请求对象
        /// </summary>
        /// <param name="uri">FTP地址</param>
        /// <param name="ftpMathod">操作命令</param>
        private FtpWebRequest OpenRequest(Uri uri, string ftpMathod)
        {
            try
            {
                _request = (FtpWebRequest) WebRequest.Create(uri);
                _request.Method = ftpMathod;
                _request.UseBinary = true;
                _request.Credentials = new NetworkCredential(UserName, Password);
                if (Proxy != null)
                {
                    _request.Proxy = Proxy;
                }
                return _request;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        #endregion
        #region 下载文件

        /// <summary>
        /// 从FTP服务器下载文件，使用与远程文件同名的文件名来保存文件
        /// </summary>
        /// <param name="remoteFileName">远程文件名</param>
        /// <param name="localPath">本地路径</param>

        public bool DownloadFile(string remoteFileName, string localPath)
        {
            return DownloadFile(remoteFileName, localPath, remoteFileName);
        }
        /// <summary>
        /// 从FTP服务器下载文件，指定本地路径和本地文件名
        /// </summary>
        /// <param name="remoteFileName">远程文件名</param>
        /// <param name="localPath">本地路径</param>
        /// <param name="LocalFilePath">保存文件的本地路径,后面带有"\"</param>
        /// <param name="localFileName">保存本地的文件名</param>
        public bool DownloadFile(string remoteFileName, string localPath, string localFileName)
        {
            byte[] bt = null;
            try
            {
                if (!IsValidFileChars(remoteFileName) || !IsValidFileChars(localFileName) || !IsValidPathChars(localPath))
                {
                    throw new Exception("非法文件名或目录名!");
                }
                if (!Directory.Exists(localPath))
                {
                    throw new Exception("本地文件路径不存在!");
                }

                var localFullPath = Path.Combine(localPath, localFileName);
                if (File.Exists(localFullPath))
                {
                    throw new Exception("当前路径下已经存在同名文件！");
                }
                bt = DownloadFile(remoteFileName);
                if (bt != null)
                {
                    var stream = new FileStream(localFullPath, FileMode.Create);
                    stream.Write(bt, 0, bt.Length);
                    stream.Flush();
                    stream.Close();
                    return true;
                }
                return false;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }

        /// <summary>
        /// 从FTP服务器下载文件，返回文件二进制数据
        /// </summary>
        /// <param name="remoteFileName">远程文件名</param>
        public byte[] DownloadFile(string remoteFileName)
        {
            try
            {
                if (!IsValidFileChars(remoteFileName))
                {
                    throw new Exception("非法文件名或目录名!");
                }
                _response = Open(new Uri(Uri + remoteFileName), WebRequestMethods.Ftp.DownloadFile);
                var reader = _response.GetResponseStream();

                var mem = new MemoryStream(1024 * 500);
                var buffer = new byte[1024];
                var bytesRead = 0;
                var totalByteRead = 0;
                while (true)
                {
                    bytesRead = reader.Read(buffer, 0, buffer.Length);
                    totalByteRead += bytesRead;
                    if (bytesRead == 0)
                        break;
                    mem.Write(buffer, 0, bytesRead);
                }
                if (mem.Length > 0)
                {
                    return mem.ToArray();
                }
                return null;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        #endregion
        #region 异步下载文件
        /// <summary>
        /// 从FTP服务器异步下载文件，指定本地路径和本地文件名
        /// </summary>
        /// <param name="remoteFileName">远程文件名</param>        
        /// <param name="localPath">保存文件的本地路径,后面带有"\"</param>
        /// <param name="localFileName">保存本地的文件名</param>
        public void DownloadFileAsync(string remoteFileName, string localPath, string localFileName)
        {
           // byte[] bt = null;
            try
            {
                if (!IsValidFileChars(remoteFileName) || !IsValidFileChars(localFileName) || !IsValidPathChars(localPath))
                {
                    throw new Exception("非法文件名或目录名!");
                }
                if (!Directory.Exists(localPath))
                {
                    throw new Exception("本地文件路径不存在!");
                }

                var localFullPath = Path.Combine(localPath, localFileName);
                if (File.Exists(localFullPath))
                {
                    throw new Exception("当前路径下已经存在同名文件！");
                }
                DownloadFileAsync(remoteFileName, localFullPath);

            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }

        /// <summary>
        /// 从FTP服务器异步下载文件，指定本地完整路径文件名
        /// </summary>
        /// <param name="remoteFileName">远程文件名</param>
        /// <param name="localFullPath">本地完整路径文件名</param>
        public void DownloadFileAsync(string remoteFileName, string localFullPath)
        {
            try
            {
                if (!IsValidFileChars(remoteFileName))
                {
                    throw new Exception("非法文件名或目录名!");
                }
                if (File.Exists(localFullPath))
                {
                    throw new Exception("当前路径下已经存在同名文件！");
                }
                var client = new MyWebClient();

                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
                client.Credentials = new NetworkCredential(UserName, Password);
                if (Proxy != null)
                {
                    client.Proxy = Proxy;
                }
                client.DownloadFileAsync(new Uri(Uri + remoteFileName), localFullPath);
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }

        /// <summary>
        /// 异步下载文件完成之后触发的事件
        /// </summary>
        /// <param name="sender">下载对象</param>
        /// <param name="e">数据信息对象</param>
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (DownloadDataCompleted != null)
            {
                DownloadDataCompleted(sender, e);
            }
        }

        /// <summary>
        /// 异步下载进度发生改变触发的事件
        /// </summary>
        /// <param name="sender">下载对象</param>
        /// <param name="e">进度信息对象</param>
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (DownloadProgressChanged != null)
            {
                DownloadProgressChanged(sender, e);
            }
        }
        #endregion
        #region 上传文件
        /// <summary>
        /// 上传文件到FTP服务器
        /// </summary>
        /// <param name="localFullPath">本地带有完整路径的文件名</param>
        public bool UploadFile(string localFullPath)
        {
            return UploadFile(localFullPath, Path.GetFileName(localFullPath), false);
        }
        /// <summary>
        /// 上传文件到FTP服务器
        /// </summary>
        /// <param name="localFullPath">本地带有完整路径的文件</param>
        /// <param name="overWriteRemoteFile">是否覆盖远程服务器上面同名的文件</param>
        public bool UploadFile(string localFullPath, bool overWriteRemoteFile)
        {
            return UploadFile(localFullPath, Path.GetFileName(localFullPath), overWriteRemoteFile);
        }
        /// <summary>
        /// 上传文件到FTP服务器
        /// </summary>
        /// <param name="localFullPath">本地带有完整路径的文件</param>
        /// <param name="remoteFileName">要在FTP服务器上面保存文件名</param>
        public bool UploadFile(string localFullPath, string remoteFileName)
        {
            return UploadFile(localFullPath, remoteFileName, false);
        }
        /// <summary>
        /// 上传文件到FTP服务器
        /// </summary>
        /// <param name="localFullPath">本地带有完整路径的文件名</param>
        /// <param name="remoteFileName">要在FTP服务器上面保存文件名</param>
        /// <param name="overWriteRemoteFile">是否覆盖远程服务器上面同名的文件</param>
        public bool UploadFile(string localFullPath, string remoteFileName, bool overWriteRemoteFile)
        {
            try
            {
                if (!IsValidFileChars(remoteFileName) || !IsValidFileChars(Path.GetFileName(localFullPath)) || !IsValidPathChars(Path.GetDirectoryName(localFullPath)))
                {
                    throw new Exception("非法文件名或目录名!");
                }
                if (File.Exists(localFullPath))
                {
                    var stream = new FileStream(localFullPath, FileMode.Open, FileAccess.Read);
                    var bt = new byte[stream.Length];
                    stream.Read(bt, 0, (Int32) stream.Length);   //注意，因为Int32的最大限制，最大上传文件只能是大约2G多一点
                    stream.Close();
                    return UploadFile(bt, remoteFileName, overWriteRemoteFile);
                }
                throw new Exception("本地文件不存在!");
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 上传文件到FTP服务器
        /// </summary>
        /// <param name="fileBytes">上传的二进制数据</param>
        /// <param name="remoteFileName">要在FTP服务器上面保存文件名</param>
        public bool UploadFile(byte[] fileBytes, string remoteFileName)
        {
            if (!IsValidFileChars(remoteFileName))
            {
                throw new Exception("非法文件名或目录名!");
            }
            return UploadFile(fileBytes, remoteFileName, false);
        }
        /// <summary>
        /// 上传文件到FTP服务器
        /// </summary>
        /// <param name="fileBytes">文件二进制内容</param>
        /// <param name="remoteFileName">要在FTP服务器上面保存文件名</param>
        /// <param name="overWriteRemoteFile">是否覆盖远程服务器上面同名的文件</param>
        public bool UploadFile(byte[] fileBytes, string remoteFileName, bool overWriteRemoteFile)
        {
            try
            {
                if (!IsValidFileChars(remoteFileName))
                {
                    throw new Exception("非法文件名！");
                }
                if (!overWriteRemoteFile && FileExist(remoteFileName))
                {
                    throw new Exception("FTP服务上面已经存在同名文件！");
                }
                _response = Open(new Uri(Uri + remoteFileName), WebRequestMethods.Ftp.UploadFile);
                var requestStream = _request.GetRequestStream();
                var mem = new MemoryStream(fileBytes);

                var buffer = new byte[1024];
                var bytesRead = 0;
                var totalRead = 0;
                while (true)
                {
                    bytesRead = mem.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    totalRead += bytesRead;
                    requestStream.Write(buffer, 0, bytesRead);
                }
                requestStream.Close();
                _response = (FtpWebResponse) _request.GetResponse();
                mem.Close();
                mem.Dispose();
                fileBytes = null;
                return true;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        #endregion
        #region 异步上传文件
        /// <summary>
        /// 异步上传文件到FTP服务器
        /// </summary>
        /// <param name="localFullPath">本地带有完整路径的文件名</param>
        public void UploadFileAsync(string localFullPath)
        {
            UploadFileAsync(localFullPath, Path.GetFileName(localFullPath), false);
        }
        /// <summary>
        /// 异步上传文件到FTP服务器
        /// </summary>
        /// <param name="localFullPath">本地带有完整路径的文件</param>
        /// <param name="overWriteRemoteFile">是否覆盖远程服务器上面同名的文件</param>
        public void UploadFileAsync(string localFullPath, bool overWriteRemoteFile)
        {
            UploadFileAsync(localFullPath, Path.GetFileName(localFullPath), overWriteRemoteFile);
        }
        /// <summary>
        /// 异步上传文件到FTP服务器
        /// </summary>
        /// <param name="localFullPath">本地带有完整路径的文件</param>
        /// <param name="remoteFileName">要在FTP服务器上面保存文件名</param>
        public void UploadFileAsync(string localFullPath, string remoteFileName)
        {
            UploadFileAsync(localFullPath, remoteFileName, false);
        }
        /// <summary>
        /// 异步上传文件到FTP服务器
        /// </summary>
        /// <param name="localFullPath">本地带有完整路径的文件名</param>
        /// <param name="remoteFileName">要在FTP服务器上面保存文件名</param>
        /// <param name="overWriteRemoteFile">是否覆盖远程服务器上面同名的文件</param>
        public void UploadFileAsync(string localFullPath, string remoteFileName, bool overWriteRemoteFile)
        {
            try
            {
                if (!IsValidFileChars(remoteFileName) || !IsValidFileChars(Path.GetFileName(localFullPath)) || !IsValidPathChars(Path.GetDirectoryName(localFullPath)))
                {
                    throw new Exception("非法文件名或目录名!");
                }
                if (!overWriteRemoteFile && FileExist(remoteFileName))
                {
                    throw new Exception("FTP服务上面已经存在同名文件！");
                }
                if (File.Exists(localFullPath))
                {
                    var client = new MyWebClient();

                    client.UploadProgressChanged += client_UploadProgressChanged;
                    client.UploadFileCompleted += client_UploadFileCompleted;
                    client.Credentials = new NetworkCredential(UserName, Password);
                    if (Proxy != null)
                    {
                        client.Proxy = Proxy;
                    }
                    client.UploadFileAsync(new Uri(Uri + remoteFileName), localFullPath);

                }
                else
                {
                    throw new Exception("本地文件不存在!");
                }
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 异步上传文件到FTP服务器
        /// </summary>
        /// <param name="fileBytes">上传的二进制数据</param>
        /// <param name="remoteFileName">要在FTP服务器上面保存文件名</param>
        public void UploadFileAsync(byte[] fileBytes, string remoteFileName)
        {
            if (!IsValidFileChars(remoteFileName))
            {
                throw new Exception("非法文件名或目录名!");
            }
            UploadFileAsync(fileBytes, remoteFileName, false);
        }
        /// <summary>
        /// 异步上传文件到FTP服务器
        /// </summary>
        /// <param name="fileBytes">文件二进制内容</param>
        /// <param name="remoteFileName">要在FTP服务器上面保存文件名</param>
        /// <param name="overWriteRemoteFile">是否覆盖远程服务器上面同名的文件</param>
        public void UploadFileAsync(byte[] fileBytes, string remoteFileName, bool overWriteRemoteFile)
        {
            try
            {

                if (!IsValidFileChars(remoteFileName))
                {
                    throw new Exception("非法文件名！");
                }
                if (!overWriteRemoteFile && FileExist(remoteFileName))
                {
                    throw new Exception("FTP服务上面已经存在同名文件！");
                }
                var tempPath = Environment.GetFolderPath(Environment.SpecialFolder.Templates);
                if (!tempPath.EndsWith("\\"))
                {
                    tempPath += "\\";
                }
                var tempFile = tempPath + Path.GetRandomFileName();
                tempFile = Path.ChangeExtension(tempFile, Path.GetExtension(remoteFileName));
                var stream = new FileStream(tempFile, FileMode.CreateNew, FileAccess.Write);
                stream.Write(fileBytes, 0, fileBytes.Length);   //注意，因为Int32的最大限制，最大上传文件只能是大约2G多一点
                stream.Flush();
                stream.Close();
                stream.Dispose();
                _isDeleteTempFile = true;
                _uploadTempFile = tempFile;
                fileBytes = null;
                UploadFileAsync(tempFile, remoteFileName, overWriteRemoteFile);



            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }

        /// <summary>
        /// 异步上传文件完成之后触发的事件
        /// </summary>
        /// <param name="sender">下载对象</param>
        /// <param name="e">数据信息对象</param>
        void client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            if (_isDeleteTempFile)
            {
                if (File.Exists(_uploadTempFile))
                {
                    File.SetAttributes(_uploadTempFile, FileAttributes.Normal);
                    File.Delete(_uploadTempFile);
                }
                _isDeleteTempFile = false;
            }
            if (UploadFileCompleted != null)
            {
                UploadFileCompleted(sender, e);
            }
        }

        /// <summary>
        /// 异步上传进度发生改变触发的事件
        /// </summary>
        /// <param name="sender">下载对象</param>
        /// <param name="e">进度信息对象</param>
        void client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            if (UploadProgressChanged != null)
            {
                UploadProgressChanged(sender, e);
            }
        }
        #endregion
        #region 列出目录文件信息
        /// <summary>
        /// 列出FTP服务器上面当前目录的所有文件和目录
        /// </summary>
        public FileStruct[] ListFilesAndDirectories()
        {
            _response = Open(Uri, WebRequestMethods.Ftp.ListDirectoryDetails);
            var stream = new StreamReader(_response.GetResponseStream(), Encoding.Default);
            var datastring = stream.ReadToEnd();
            var list = GetList(datastring);
            return list;
        }
        /// <summary>
        /// 列出FTP服务器上面当前目录的所有文件
        /// </summary>
        public FileStruct[] ListFiles()
        {
            var listAll = ListFilesAndDirectories();
            var listFile = new List<FileStruct>();
            foreach (var file in listAll)
            {
                if (!file.IsDirectory)
                {
                    listFile.Add(file);
                }
            }
            return listFile.ToArray();
        }

        /// <summary>
        /// 列出FTP服务器上面当前目录的所有的目录
        /// </summary>
        public FileStruct[] ListDirectories()
        {
            var listAll = ListFilesAndDirectories();
            var listDirectory = new List<FileStruct>();
            foreach (var file in listAll)
            {
                if (file.IsDirectory)
                {
                    listDirectory.Add(file);
                }
            }
            return listDirectory.ToArray();
        }
        /// <summary>
        /// 获得文件和目录列表
        /// </summary>
        /// <param name="datastring">FTP返回的列表字符信息</param>
        private FileStruct[] GetList(string datastring)
        {
            var myListArray = new List<FileStruct>();
            var dataRecords = datastring.Split('\n');
            var directoryListStyle = GuessFileListStyle(dataRecords);
            foreach (var s in dataRecords)
            {
                if (directoryListStyle != FileListStyle.Unknown && s != "")
                {
                    var f = new FileStruct();
                    f.Name = "..";
                    switch (directoryListStyle)
                    {
                    case FileListStyle.UnixStyle:
                        f = ParseFileStructFromUnixStyleRecord(s);
                        break;
                    case FileListStyle.WindowsStyle:
                        f = ParseFileStructFromWindowsStyleRecord(s);
                        break;
                    }
                    if (!(f.Name == "." || f.Name == ".."))
                    {
                        myListArray.Add(f);
                    }
                }
            }
            return myListArray.ToArray();
        }

        /// <summary>
        /// 从Windows格式中返回文件信息
        /// </summary>
        /// <param name="record">文件信息</param>
        private FileStruct ParseFileStructFromWindowsStyleRecord(string record)
        {
            var f = new FileStruct();
            var processstr = record.Trim();
            var dateStr = processstr.Substring(0, 8);
            processstr = (processstr.Substring(8, processstr.Length - 8)).Trim();
            var timeStr = processstr.Substring(0, 7);
            processstr = (processstr.Substring(7, processstr.Length - 7)).Trim();
            var myDtfi = new CultureInfo("en-US", false).DateTimeFormat;
            myDtfi.ShortTimePattern = "t";
            f.CreateTime = DateTime.Parse(dateStr + " " + timeStr, myDtfi);
            if (processstr.Substring(0, 5) == "<DIR>")
            {
                f.IsDirectory = true;
                processstr = (processstr.Substring(5, processstr.Length - 5)).Trim();
            }
            else
            {
                var strs = processstr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);   // true);
                processstr = strs[1];
                f.IsDirectory = false;
            }
            f.Name = processstr;
            return f;
        }


        /// <summary>
        /// 判断文件列表的方式Window方式还是Unix方式
        /// </summary>
        /// <param name="recordList">文件信息列表</param>
        private FileListStyle GuessFileListStyle(string[] recordList)
        {
            foreach (var s in recordList)
            {
                if (s.Length > 10
                 && Regex.IsMatch(s.Substring(0, 10), "(-|d)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)"))
                {
                    return FileListStyle.UnixStyle;
                }
                if (s.Length > 8
                    && Regex.IsMatch(s.Substring(0, 8), "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]"))
                {
                    return FileListStyle.WindowsStyle;
                }
            }
            return FileListStyle.Unknown;
        }

        /// <summary>
        /// 从Unix格式中返回文件信息
        /// </summary>
        /// <param name="record">文件信息</param>
        private FileStruct ParseFileStructFromUnixStyleRecord(string record)
        {
            var f = new FileStruct();
            var processstr = record.Trim();
            f.Flags = processstr.Substring(0, 10);
            f.IsDirectory = (f.Flags[0] == 'd');
            processstr = (processstr.Substring(11)).Trim();
            _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);   //跳过一部分
            f.Owner = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
            f.Group = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
            _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);   //跳过一部分
            var yearOrTime = processstr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2];
            if (yearOrTime.IndexOf(":") >= 0)  //time
            {
                processstr = processstr.Replace(yearOrTime, DateTime.Now.Year.ToString());
            }
            f.CreateTime = DateTime.Parse(_cutSubstringFromStringWithTrim(ref processstr, ' ', 8));
            f.Name = processstr;   //最后就是名称
            return f;
        }

        /// <summary>
        /// 按照一定的规则进行字符串截取
        /// </summary>
        /// <param name="s">截取的字符串</param>
        /// <param name="c">查找的字符</param>
        /// <param name="startIndex">查找的位置</param>
        private string _cutSubstringFromStringWithTrim(ref string s, char c, int startIndex)
        {
            var pos1 = s.IndexOf(c, startIndex);
            var retString = s.Substring(0, pos1);
            s = (s.Substring(pos1)).Trim();
            return retString;
        }
        #endregion
        #region 目录或文件存在的判断
        /// <summary>
        /// 判断当前目录下指定的子目录是否存在
        /// </summary>
        /// <param name="remoteDirectoryName">指定的目录名</param>
        public bool DirectoryExist(string remoteDirectoryName)
        {
            try
            {
                if (!IsValidPathChars(remoteDirectoryName))
                {
                    throw new Exception("目录名非法！");
                }
                var listDir = ListDirectories();
                foreach (var dir in listDir)
                {
                    if (dir.Name == remoteDirectoryName)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 判断一个远程文件是否存在服务器当前目录下面
        /// </summary>
        /// <param name="remoteFileName">远程文件名</param>
        public bool FileExist(string remoteFileName)
        {
            try
            {
                if (!IsValidFileChars(remoteFileName))
                {
                    throw new Exception("文件名非法！");
                }
                var listFile = ListFiles();
                foreach (var file in listFile)
                {
                    if (file.Name == remoteFileName)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        #endregion
        #region 删除文件
        /// <summary>
        /// 从FTP服务器上面删除一个文件
        /// </summary>
        /// <param name="remoteFileName">远程文件名</param>
        public void DeleteFile(string remoteFileName)
        {
            try
            {
                if (!IsValidFileChars(remoteFileName))
                {
                    throw new Exception("文件名非法！");
                }
                _response = Open(new Uri(Uri + remoteFileName), WebRequestMethods.Ftp.DeleteFile);
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        #endregion
        #region 重命名文件
        /// <summary>
        /// 更改一个文件的名称或一个目录的名称
        /// </summary>
        /// <param name="remoteFileName">原始文件或目录名称</param>
        /// <param name="newFileName">新的文件或目录的名称</param>
        public bool ReName(string remoteFileName, string newFileName)
        {
            try
            {
                if (!IsValidFileChars(remoteFileName) || !IsValidFileChars(newFileName))
                {
                    throw new Exception("文件名非法！");
                }
                if (remoteFileName == newFileName)
                {
                    return true;
                }
                if (FileExist(remoteFileName))
                {
                    _request = OpenRequest(new Uri(Uri + remoteFileName), WebRequestMethods.Ftp.Rename);
                    _request.RenameTo = newFileName;
                    _response = (FtpWebResponse) _request.GetResponse();

                }
                else
                {
                    throw new Exception("文件在服务器上不存在！");
                }
                return true;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        #endregion
        #region 拷贝、移动文件
        /// <summary>
        /// 把当前目录下面的一个文件拷贝到服务器上面另外的目录中，注意，拷贝文件之后，当前工作目录还是文件原来所在的目录
        /// </summary>
        /// <param name="remoteFile">当前目录下的文件名</param>
        /// <param name="directoryName">新目录名称。
        /// 说明：如果新目录是当前目录的子目录，则直接指定子目录。如: SubDirectory1/SubDirectory2 ；
        /// 如果新目录不是当前目录的子目录，则必须从根目录一级一级的指定。如： ./NewDirectory/SubDirectory1/SubDirectory2
        /// </param>
        /// <returns></returns>
        public bool CopyFileToAnotherDirectory(string remoteFile, string directoryName)
        {
            var currentWorkDir = DirectoryPath;
            try
            {
                var bt = DownloadFile(remoteFile);
                GotoDirectory(directoryName);
                var success = UploadFile(bt, remoteFile, false);
                DirectoryPath = currentWorkDir;
                return success;
            }
            catch (Exception ep)
            {
                DirectoryPath = currentWorkDir;
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 把当前目录下面的一个文件移动到服务器上面另外的目录中，注意，移动文件之后，当前工作目录还是文件原来所在的目录
        /// </summary>
        /// <param name="remoteFile">当前目录下的文件名</param>
        /// <param name="directoryName">新目录名称。
        /// 说明：如果新目录是当前目录的子目录，则直接指定子目录。如: SubDirectory1/SubDirectory2 ；
        /// 如果新目录不是当前目录的子目录，则必须从根目录一级一级的指定。如： ./NewDirectory/SubDirectory1/SubDirectory2
        /// </param>
        /// <returns></returns>
        public bool MoveFileToAnotherDirectory(string remoteFile, string directoryName)
        {
            var currentWorkDir = DirectoryPath;
            try
            {
                if (directoryName == "")
                    return false;
                if (!directoryName.StartsWith("/"))
                    directoryName = "/" + directoryName;
                if (!directoryName.EndsWith("/"))
                    directoryName += "/";
                var success = ReName(remoteFile, directoryName + remoteFile);
                DirectoryPath = currentWorkDir;
                return success;
            }
            catch (Exception ep)
            {
                DirectoryPath = currentWorkDir;
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        #endregion
        #region 建立、删除子目录
        /// <summary>
        /// 在FTP服务器上当前工作目录建立一个子目录
        /// </summary>
        /// <param name="directoryName">子目录名称</param>
        public bool MakeDirectory(string directoryName)
        {
            try
            {
                if (!IsValidPathChars(directoryName))
                {
                    throw new Exception("目录名非法！");
                }
                if (DirectoryExist(directoryName))
                {
                    throw new Exception("服务器上面已经存在同名的文件名或目录名！");
                }
                _response = Open(new Uri(Uri + directoryName), WebRequestMethods.Ftp.MakeDirectory);
                return true;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 从当前工作目录中删除一个子目录
        /// </summary>
        /// <param name="directoryName">子目录名称</param>
        public bool RemoveDirectory(string directoryName)
        {
            try
            {
                if (!IsValidPathChars(directoryName))
                {
                    throw new Exception("目录名非法！");
                }
                if (!DirectoryExist(directoryName))
                {
                    throw new Exception("服务器上面不存在指定的文件名或目录名！");
                }
                _response = Open(new Uri(Uri + directoryName), WebRequestMethods.Ftp.RemoveDirectory);
                return true;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        #endregion
        #region 文件、目录名称有效性判断
        /// <summary>
        /// 判断目录名中字符是否合法
        /// </summary>
        /// <param name="directoryName">目录名称</param>
        public bool IsValidPathChars(string directoryName)
        {
            var invalidPathChars = Path.GetInvalidPathChars();
            var dirChar = directoryName.ToCharArray();
            foreach (var c in dirChar)
            {
                if (Array.BinarySearch(invalidPathChars, c) >= 0)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 判断文件名中字符是否合法
        /// </summary>
        /// <param name="fileName">文件名称</param>
        public bool IsValidFileChars(string fileName)
        {
            var invalidFileChars = Path.GetInvalidFileNameChars();
            var nameChar = fileName.ToCharArray();
            foreach (var c in nameChar)
            {
                if (Array.BinarySearch(invalidFileChars, c) >= 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
        #region 目录切换操作
        /// <summary>
        /// 进入一个目录
        /// </summary>
        /// <param name="directoryName">
        /// 新目录的名字。 
        /// 说明：如果新目录是当前目录的子目录，则直接指定子目录。如: SubDirectory1/SubDirectory2 ； 
        /// 如果新目录不是当前目录的子目录，则必须从根目录一级一级的指定。如： ./NewDirectory/SubDirectory1/SubDirectory2
        /// </param>
        public bool GotoDirectory(string directoryName)
        {
            var currentWorkPath = DirectoryPath;
            try
            {
                directoryName = directoryName.Replace("\\", "/");
                var directoryNames = directoryName.Split('/');
                if (directoryNames[0] == ".")
                {
                    DirectoryPath = "/";
                    if (directoryNames.Length == 1)
                    {
                        return true;
                    }
                    Array.Clear(directoryNames, 0, 1);
                }
                var success = false;
                foreach (var dir in directoryNames)
                {
                    if (dir != null)
                    {
                        success = EnterOneSubDirectory(dir);
                        if (!success)
                        {
                            DirectoryPath = currentWorkPath;
                            return false;
                        }
                    }
                }
                return success;

            }
            catch (Exception ep)
            {
                DirectoryPath = currentWorkPath;
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 从当前工作目录进入一个子目录
        /// </summary>
        /// <param name="directoryName">子目录名称</param>
        private bool EnterOneSubDirectory(string directoryName)
        {
            try
            {
                if (directoryName.IndexOf("/") >= 0 || !IsValidPathChars(directoryName))
                {
                    throw new Exception("目录名非法!");
                }
                if (directoryName.Length > 0 && DirectoryExist(directoryName))
                {
                    if (!directoryName.EndsWith("/"))
                    {
                        directoryName += "/";
                    }
                    _directoryPath += directoryName;
                    return true;
                }
                return false;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 从当前工作目录往上一级目录
        /// </summary>
        public bool ComeoutDirectory()
        {
            if (_directoryPath == "/")
            {
                ErrorMsg = "当前目录已经是根目录！";
                throw new Exception("当前目录已经是根目录！");
            }
            var sp = new char[1] { '/' };

            var strDir = _directoryPath.Split(sp, StringSplitOptions.RemoveEmptyEntries);
            if (strDir.Length == 1)
            {
                _directoryPath = "/";
            }
            else
            {
                _directoryPath = String.Join("/", strDir, 0, strDir.Length - 1);
            }
            return true;

        }
        #endregion
        #region 重载WebClient，支持FTP进度
        internal class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                var req = (FtpWebRequest) base.GetWebRequest(address);
                req.UsePassive = false;
                return req;
            }
        }
        #endregion
    }
}

/*
例子：

 


调用方法，目前只用上传功能：
    定义全局私有变量：
 private clsFTP cf;
   按钮事件：
        private void btn_upFile_Click(object sender, EventArgs e)
        {
            lb_upload.Text = "正在上传文件，请等待...";
             cf = new clsFTP(new Uri("http://www.cnblogs.com/zhangjun1130/admin/ftp://192.168.43.55/"), "temp", "temp");
            string localFile = Application.StartupPath.ToString() + "http://www.cnblogs.com/zhangjun1130/admin/file://output//zt.rar";
             cf.UploadProgressChanged+=new clsFTP.De_UploadProgressChanged(cf_UploadProgressChanged);
             cf.UploadFileCompleted+=new clsFTP.De_UploadFileCompleted(cf_UploadFileCompleted);
             cf.UploadFileAsync(localFile, true);  //调用异步传输，若有文件存在则覆盖。
        }
   事件捆绑，反映上传进度：
        public void cf_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            this.pgrBarFileUpload.Maximum = (int)e.TotalBytesToSend;
            this.pgrBarFileUpload.Value =(int) e.BytesSent;
            lb_upload.Text = string.Format("文件总大小：{0}k，已经上传： {1}k。", e.TotalBytesToSend/1024,e.BytesSent/1024);
        }
        public void cf_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
                        try
            {
                lb_upload.Text = "无法连接到服务器，或者用户登陆失败！";
                lb_error.Text =e.Error.Message.ToString();
            }
            catch
            {
                lb_upload.Text = "文件上传成功！";
                lb_error.Text = "";
            }
        }
*/