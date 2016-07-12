using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DSS.BLL
{
    public class FtpLib
    {
      //  private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(FTPLib));
        string _ftpServerIp;
        string _ftpUserId;
        string _ftpPassword;
        FtpWebRequest _reqFtp;
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
        //連接FTP
        private void Connect(String path)
        {
            //根據URL創建FTP WebRequest物件
            _reqFtp = (FtpWebRequest)WebRequest.Create(new Uri(path));
            //指定數據傳輸類型
            _reqFtp.UseBinary = true;
            //FTP用戶名和密碼
            _reqFtp.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
        }
        public FtpLib(string ftpServerIp, string ftpUserId, string ftpPassword)
        {
            _ftpServerIp = ftpServerIp;
            _ftpUserId = ftpUserId;
            _ftpPassword = ftpPassword;
        }
        //下面的代碼示例了如何從FTP服務器上獲得文件列表
        private string[] GetFileList(string path, string wrMethods)
        {
            string[] downloadFiles;
            var result = new StringBuilder();
            try
            {
                Connect(path);
                _reqFtp.Method = wrMethods;
                var response = _reqFtp.GetResponse();
                var reader = new StreamReader(response.GetResponseStream(), Encoding.Default); //中文文件名
                var line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }
        //下面的代碼實現了從FTP服務器上傳文件的功\u-32515 能
        public bool Upload(string filename, string newfilename, string dirname)
        {
            var retValue = false;
            try
            {
                var fileInf = new FileInfo(filename);
                //文件名稱為上傳文件原來的名稱
                //string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
                //上傳文件名稱改為新的文件名稱
                var uri = "ftp://" + _ftpServerIp + "/" + dirname + "/" + newfilename;
                //連接
                Connect(uri);
                //默認為TRUE，連接不會被關閉
                //在一個命令之後被執行
                _reqFtp.KeepAlive = false;
                //執行什麼命令
                _reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
                //上傳文件時通知服務器文件的大小
                _reqFtp.ContentLength = fileInf.Length;
                //緩衝大小設置為kb
                var buffLength = 2048;
                var buff = new byte[buffLength];
                int contentLen;
                //打開一個文件流(System.IO.FileStream)去讀取上傳的文件
                var fs = fileInf.OpenRead();
                //把上傳的文件寫入流
                var strm = _reqFtp.GetRequestStream();
                //每次讀文件流的KB
                contentLen = fs.Read(buff, 0, buffLength);
                //流內容沒有結束
                while (contentLen != 0)
                {
                    //把內容從FILE STREAM 寫入UPLOAD STREAM
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                //關閉兩個流
                strm.Close();
                fs.Close();
                retValue = true;
            }
            catch (Exception ex)
            {
                retValue = false;
                MessageBox.Show(ex.Message, "Upload Error");
            }
            return retValue;
        }
        public bool CheckFileNameExists(string filePath, string fileName, out string errorinfo)
        {
            var retValue = false;
            try
            {
                var onlyFileName = Path.GetFileName(fileName);
                var newFileName = filePath + "\\" + onlyFileName;
                if (File.Exists(newFileName))
                {
                    errorinfo = string.Format("本地文件{0}已存在,", newFileName);
                    return true;
                }
                errorinfo = "";
            }
            catch (Exception ex)
            {
                retValue = false;
                errorinfo = string.Format("因{0},无法下载uc1", ex.Message);
            }
            return retValue;
        }
        //下面的代碼實現了從FTP服務器下載文件的功\u-32515 能
        public bool Download(string filePath, string fileName, out string errorinfo)
        {
            var retValue = false;
            try
            {
                var onlyFileName = Path.GetFileName(fileName);
                var newFileName = filePath + "\\" + onlyFileName;
                //if (File.Exists(newFileName))
                //{
                //    errorinfo = string.Format("本地文件{0}已存在，無法下載", newFileName);
                //    return false;
                //}
                var url = "ftp://" + _ftpServerIp + "/" + fileName;
                //連接
                Connect(url);
                _reqFtp.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
                var response = (FtpWebResponse)_reqFtp.GetResponse();
                var ftpStream = response.GetResponseStream();
                var cl = response.ContentLength;
                var bufferSize = 2048;
                int readCount;
                var buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                var outputStream = new FileStream(newFileName, FileMode.Create);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
                errorinfo = "";
                retValue = true;
            }
            catch (Exception ex)
            {
                retValue = false;
                errorinfo = string.Format("因{0},无法下载uc1", ex.Message);
            }
            return retValue;
        }
        //刪除文件
        public void DeleteFileName(string fileName)
        {
            try
            {
                var fileInf = new FileInfo(fileName);
                var uri = "ftp://" + _ftpServerIp + "/" + fileInf.Name;
                //連接
                Connect(uri);
                //默認為TRUE，連接不會被關閉
                //在一個命令之後被執行
                _reqFtp.KeepAlive = false;
                //執行執行什麼命令
                _reqFtp.Method = WebRequestMethods.Ftp.DeleteFile;
                var response = (FtpWebResponse)_reqFtp.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "刪除錯誤");
            }
        }
        //創建目錄
        public bool MakeDir(string dirName)
        {
            var retValue = false;
            try
            {
                if (!DirectoryExist(dirName))
                {
                    var uri = "ftp://" + _ftpServerIp + "/" + dirName;
                    //連接
                    Connect(uri);
                    _reqFtp.Method = WebRequestMethods.Ftp.MakeDirectory;
                    var response = (FtpWebResponse)_reqFtp.GetResponse();
                    response.Close();
                }
                retValue = true;
            }
            catch (Exception ex)
            {
                retValue = false;
                MessageBox.Show(ex.Message);
            }
            return retValue;
        }
        //刪除目錄
        public void DelDir(string dirName)
        {
            try
            {
                var uri = "ftp://" + _ftpServerIp + "/" + dirName;
                //連接
                Connect(uri);
                _reqFtp.Method = WebRequestMethods.Ftp.RemoveDirectory;
                var response = (FtpWebResponse)_reqFtp.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //獲得文件大小
        public long GetFileSize(string filename)
        {
            long fileSize = 0;
            try
            {
                var fileInf = new FileInfo(filename);
                var uri = "ftp://" + _ftpServerIp + "/" + fileInf.Name;
                //連接
                Connect(uri);
                _reqFtp.Method = WebRequestMethods.Ftp.GetFileSize;
                var response = (FtpWebResponse)_reqFtp.GetResponse();
                fileSize = response.ContentLength;
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return fileSize;
        }
        //文件改名
        public void Rename(string currentFilename, string newFilename)
        {
            try
            {
                var fileInf = new FileInfo(currentFilename);
                var uri = "ftp://" + _ftpServerIp + "/" + fileInf.Name;
                //連接
                Connect(uri);
                _reqFtp.Method = WebRequestMethods.Ftp.Rename;
                _reqFtp.RenameTo = newFilename;
                var response = (FtpWebResponse)_reqFtp.GetResponse();
                //Stream ftpStream = response.GetResponseStream();
                //ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //下面的代碼示例了如何從FTP服務器上獲得文件列表
        public string[] GetFileList(string path)
        {
            return GetFileList("ftp://" + _ftpServerIp + "/" + path, WebRequestMethods.Ftp.ListDirectory);
        }
        //下面的代碼示例了如何從FTP服務器上獲得文件列表
        public string[] GetFileList()
        {
            return GetFileList("ftp://" + _ftpServerIp + "/", WebRequestMethods.Ftp.ListDirectory);
        }
        //獲得文件明細
        public string[] GetFilesDetailList()
        {
            return GetFileList("ftp://" + _ftpServerIp + "/", WebRequestMethods.Ftp.ListDirectoryDetails);
        }
        //獲得文件明細
        public string[] GetFilesDetailList(string path)
        {
            return GetFileList("ftp://" + _ftpServerIp + "/" + path, WebRequestMethods.Ftp.ListDirectoryDetails);
        }
        #region "獲取目錄文件信息"
        /// <summary>
        /// 列出FTP服务u22120 器上面当u21069 前目录u30340 的所有文件和目录par         /// </summary>
        public FileStruct[] ListFilesAndDirectories(string path)
        {
            Connect(path);
            _reqFtp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            FtpWebResponse response = null;
            response = (FtpWebResponse)_reqFtp.GetResponse();
            //Response = Open(this.Uri, WebRequestMethods.Ftp.ListDirectoryDetails);
            var stream = new StreamReader(response.GetResponseStream(), Encoding.Default);
            var datastring = stream.ReadToEnd();
            var list = GetList(datastring);
            return list;
        }
        /// <summary>
        /// 獲取FTP服務器上面當前目錄的所有文件
        /// </summary>
        public FileStruct[] ListFiles()
        {
            var listAll = ListFilesAndDirectories("ftp://" + _ftpServerIp + "/");
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
        /// 獲取FTP服務器上面當前目錄的所有目錄
        /// </summary>
        public FileStruct[] ListDirectories()
        {
            var listAll = ListFilesAndDirectories("ftp://" + _ftpServerIp + "/");
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
        /// 獲取文件和目錄列表
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
        /// 從Windows格式中返回文件信息
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
        /// 判斷文件列表的方式Window方式還是Unix方式
        /// </summary>
        /// <param name="recordList">文件信息列表</param>
        private FileListStyle GuessFileListStyle(string[] recordList)
        {
            foreach (var s in recordList)
            {
                if (s.Length > 10 && Regex.IsMatch(s.Substring(0, 10), "(-|d)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)"))
                {
                    return FileListStyle.UnixStyle;
                }
                if (s.Length > 8 && Regex.IsMatch(s.Substring(0, 8), "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]"))
                {
                    return FileListStyle.WindowsStyle;
                }
            }
            return FileListStyle.Unknown;
        }
        /// <summary>
        /// 從Unix格式中返回文件信息
        /// </summary>
        /// <param name="record">文件信息</param>
        private FileStruct ParseFileStructFromUnixStyleRecord(string record)
        {
            var f = new FileStruct();
            var processstr = record.Trim();
            f.Flags = processstr.Substring(0, 10);
            f.IsDirectory = (f.Flags[0] == 'd');
            processstr = (processstr.Substring(11)).Trim();
            _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);   //跳過一部分
            f.Owner = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
            f.Group = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
            _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);   //跳過一部分
            var yearOrTime = processstr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2];
            if (yearOrTime.IndexOf(":") >= 0)  //time
            {
                processstr = processstr.Replace(yearOrTime, DateTime.Now.Year.ToString());
            }
            f.CreateTime = DateTime.Parse(_cutSubstringFromStringWithTrim(ref processstr, ' ', 8));
            f.Name = processstr;   //最後就是名稱
            return f;
        }
        /// <summary>
        /// 按照一定的規則進行字符串截取
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
        #region "判斷目錄或文件是否存在"
        /// <summary>
        /// 判斷當前目錄下指定的子目錄是否存在
        /// </summary>
        /// <param name="remoteDirectoryName">指定的目錄名</param>
        public bool DirectoryExist(string remoteDirectoryName)
        {
            try
            {
                if (!IsValidPathChars(remoteDirectoryName))
                {
                    throw new Exception("目錄名含有無法解析的字符，請確認！");
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 判斷一個遠程文件是否存在服務器當前目錄下面
        /// </summary>
        /// <param name="remoteFileName">遠程文件名</param>
        public bool FileExist(string remoteFileName)
        {
            try
            {
                if (!IsValidFileChars(remoteFileName))
                {
                    throw new Exception("文件名含有無法解析的字符，請確認！");
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region "文件，目錄名稱有效性判斷"
        /// <summary>
        /// 判斷目錄名中字符是否合法
        /// </summary>
        /// <param name="directoryName">目錄名稱</param>
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
        /// 判斷文件名中字符是否合法
        /// </summary>
        /// <param name="fileName">文件名稱</param>
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
        #region "註釋"
        /*
        #region 删除文件
        /// <summary>
        /// 从TP服务u22120 器上面删u-27036 除一个u25991 文件
        /// </summary>
        /// <param name="RemoteFileName">远uc2程文件名</param>
        public void DeleteFile(string RemoteFileName)
        {
            try
            {
                if (!IsValidFileChars(RemoteFileName))
                {
                    throw new Exception("文件名非法！");
                }
                Response = Open(new Uri(this.Uri.ToString() + RemoteFileName), WebRequestMethods.Ftp.DeleteFile);
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
        /// 更改一个u25991 文件的名称u25110 或一个u30446 目录u30340 的名称par         /// </summary>
        /// <param name="RemoteFileName">原始文件或目录u21517 名称uc1</param>
        /// <param name="NewFileName">新的文件或目录u30340 的名称uc1</param>
        public bool ReName(string RemoteFileName, string NewFileName)
        {
            try
            {
                if (!IsValidFileChars(RemoteFileName) || !IsValidFileChars(NewFileName))
                {
                    throw new Exception("文件名非法！");
                }
                if (RemoteFileName == NewFileName)
                {
                    return true;
                }
                if (FileExist(RemoteFileName))
                {
                    Request = OpenRequest(new Uri(this.Uri.ToString() + RemoteFileName), WebRequestMethods.Ftp.Rename);
                    Request.RenameTo = NewFileName;
                    Response = (FtpWebResponse)Request.GetResponse();
                }
                else
                {
                    throw new Exception("文件在服务u22120 器上不存在！");
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
        #region 拷贝u12289 、移动u25991 文件
        /// <summary>
        /// 把当u21069 前目录u19979 下面的一个u25991 文件拷贝u21040 到服务u22120 器上面另外的目录u20013 中，注意，拷贝u25991 文件之后，当u21069 前工作目录u-28712 ?是文件原来u25152 所在的目录par         /// </summary>
        /// <param name="RemoteFile">当uc2前目录u19979 下的文件名</param>
        /// <param name="DirectoryName">新目录u21517 名称u12290 。
        /// 说uc2明：如果新目录u26159 是当u21069 前目录u30340 的子目录u-244 ，则u30452 直接指定子目录u12290 。如: SubDirectory1/SubDirectory2 ；
        /// 如果新目录u19981 不是当u21069 前目录u30340 的子目录u-244 ，则u24517 必须u20174 ?根目录u19968 一级u19968 一级u30340 的指定。如：./NewDirectory/SubDirectory1/SubDirectory2
        /// </param>
        /// <returns></returns>
        public bool CopyFileToAnotherDirectory(string RemoteFile, string DirectoryName)
        {
            string CurrentWorkDir = this.DirectoryPath;
            try
            {
                byte[] bt = DownloadFile(RemoteFile);
                GotoDirectory(DirectoryName);
                bool Success = UploadFile(bt, RemoteFile, false);
                this.DirectoryPath = CurrentWorkDir;
                return Success;
            }
            catch (Exception ep)
            {
                this.DirectoryPath = CurrentWorkDir;
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 把当u21069 前目录u19979 下面的一个u25991 文件移动u21040 到服务u22120 器上面另外的目录u20013 中，注意，移动u25991 文件之后，当u21069 前工作目录u-28712 ?是文件原来u25152 所在的目录par         /// </summary>
        /// <param name="RemoteFile">当uc2前目录u19979 下的文件名</param>
        /// <param name="DirectoryName">新目录u21517 名称u12290 。
        /// 说uc2明：如果新目录u26159 是当u21069 前目录u30340 的子目录u-244 ，则u30452 直接指定子目录u12290 。如: SubDirectory1/SubDirectory2 ；
        /// 如果新目录u19981 不是当u21069 前目录u30340 的子目录u-244 ，则u24517 必须u20174 ?根目录u19968 一级u19968 一级u30340 的指定。如：./NewDirectory/SubDirectory1/SubDirectory2
        /// </param>
        /// <returns></returns>
        public bool MoveFileToAnotherDirectory(string RemoteFile, string DirectoryName)
        {
            string CurrentWorkDir = this.DirectoryPath;
            try
            {
                if (DirectoryName == "")
                    return false;
                if (!DirectoryName.StartsWith("/"))
                    DirectoryName = "/" + DirectoryName;
                if (!DirectoryName.EndsWith("/"))
                    DirectoryName += "/";
                bool Success = ReName(RemoteFile, DirectoryName + RemoteFile);
                this.DirectoryPath = CurrentWorkDir;
                return Success;
            }
            catch (Exception ep)
            {
                this.DirectoryPath = CurrentWorkDir;
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        #endregion
        #region 建立、删u-27036 除子目录par         /// <summary>
        /// 在FTP服务u22120 器上当u21069 前工作目录u24314 建立一个u23376 子目录par         /// </summary>
        /// <param name="DirectoryName">子目录u21517 名称uc1</param>
        public bool MakeDirectory(string DirectoryName)
        {
            try
            {
                if (!IsValidPathChars(DirectoryName))
                {
                    throw new Exception("目录u21517 名非法！");
                }
                if (DirectoryExist(DirectoryName))
                {
                    throw new Exception("服务u22120 器上面已经u23384 存在同名的文件名或目录u21517 名！");
                }
                Response = Open(new Uri(this.Uri.ToString() + DirectoryName), WebRequestMethods.Ftp.MakeDirectory);
                return true;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 从当前工作目录u20013 中删u-27036 除一个u23376 子目录par         /// </summary>
        /// <param name="DirectoryName">子目录u21517 名称uc1</param>
        public bool RemoveDirectory(string DirectoryName)
        {
            try
            {
                if (!IsValidPathChars(DirectoryName))
                {
                    throw new Exception("目录u21517 名非法！");
                }
                if (!DirectoryExist(DirectoryName))
                {
                    throw new Exception("服务u22120 器上面不存在指定的文件名或目录u21517 名！");
                }
                Response = Open(new Uri(this.Uri.ToString() + DirectoryName), WebRequestMethods.Ftp.RemoveDirectory);
                return true;
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        #endregion
        #region 目录u20999 切换u25805 操作
        /// <summary>
        /// 进uc2入一个u30446 目录par         /// </summary>
        /// <param name="DirectoryName">
        /// 新目录u30340 的名字。
        /// 说明：如果新目录u26159 是当u21069 前目录u30340 的子目录u-244 ，则u30452 直接指定子目录u12290 。如: SubDirectory1/SubDirectory2 ；
        /// 如果新目录u19981 不是当u21069 前目录u30340 的子目录u-244 ，则u24517 必须u20174 ?根目录u19968 一级u19968 一级u30340 的指定。如：./NewDirectory/SubDirectory1/SubDirectory2
        /// </param>
        public bool GotoDirectory(string DirectoryName)
        {
            string CurrentWorkPath = this.DirectoryPath;
            try
            {
                DirectoryName = DirectoryName.Replace("\\", "/");
                string[] DirectoryNames = DirectoryName.Split(new char[] { '/' });
                if (DirectoryNames[0] == ".")
                {
                    this.DirectoryPath = "/";
                    if (DirectoryNames.Length == 1)
                    {
                        return true;
                    }
                    Array.Clear(DirectoryNames, 0, 1);
                }
                bool Success = false;
                foreach (string dir in DirectoryNames)
                {
                    if (dir != null)
                    {
                        Success = EnterOneSubDirectory(dir);
                        if (!Success)
                        {
                            this.DirectoryPath = CurrentWorkPath;
                            return false;
                        }
                    }
                }
                return Success;
            }
            catch (Exception ep)
            {
                this.DirectoryPath = CurrentWorkPath;
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 从当前工作目录u-28709 ?入一个u23376 子目录par         /// </summary>
        /// <param name="DirectoryName">子目录u21517 名称uc1</param>
        private bool EnterOneSubDirectory(string DirectoryName)
        {
            try
            {
                if (DirectoryName.IndexOf("/") >= 0 || !IsValidPathChars(DirectoryName))
                {
                    throw new Exception("目录u21517 名非法!");
                }
                if (DirectoryName.Length > 0 && DirectoryExist(DirectoryName))
                {
                    if (!DirectoryName.EndsWith("/"))
                    {
                        DirectoryName += "/";
                    }
                    _DirectoryPath += DirectoryName;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ep)
            {
                ErrorMsg = ep.ToString();
                throw ep;
            }
        }
        /// <summary>
        /// 从当前工作目录u24448 往上一级u30446 目录par         /// </summary>
        public bool ComeoutDirectory()
        {
            if (_DirectoryPath == "/")
            {
                ErrorMsg = "当uc2前目录u24050 已经u26159 是根目录u-255 ！";
                throw new Exception("当前目录u24050 已经u26159 是根目录u-255 ！");
            }
            char[] sp = new char[1] { '/' };
            string[] strDir = _DirectoryPath.Split(sp, StringSplitOptions.RemoveEmptyEntries);
            if (strDir.Length == 1)
            {
                _DirectoryPath = "/";
            }
            else
            {
                _DirectoryPath = String.Join("/", strDir, 0, strDir.Length - 1);
            }
            return true;
        }
        #endregion
        */
        #endregion
    }
}