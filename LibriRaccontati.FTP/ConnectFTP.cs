using System;
using System.IO;
using System.Net;

namespace LibriRaccontati.FTP
{
    public class ConnectFtp
    {
        protected string FtpServerIp;
        protected string FtpUserId;
        protected string FtpPassword;
        public ConnectFtp()
        {
            FtpServerIp = "FTP IP";
            FtpUserId = "FTP User ID";
            FtpPassword = "FTP Password";
        }
        public bool Download(string filePath, string fileName)
        {
            try
            {
                var outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

                var reqFtp = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + FtpServerIp + "/FTP Address/" + fileName));
                reqFtp.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFtp.UseBinary = true;
                reqFtp.Credentials = new NetworkCredential(FtpUserId, FtpPassword);
                var response = (FtpWebResponse)reqFtp.GetResponse();
                var ftpStream = response.GetResponseStream();
                const int bufferSize = 2048;
                var buffer = new byte[bufferSize];

                if (ftpStream != null)
                {
                    var readCount = ftpStream.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                        outputStream.Write(buffer, 0, readCount);
                        readCount = ftpStream.Read(buffer, 0, bufferSize);
                    }
                }

                ftpStream?.Close();
                outputStream.Close();
                response.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
