using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace ConnectSFTP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = "sftp-catalogue.pedidosya.com",
                    UserName = "ec_pharmacys",
                    PortNumber = 22,
                    SshHostKeyFingerprint = "ssh-rsa 2048 34:cc:4e:5b:73:ce:73:e8:cd:2f:14:10:97:cf:40:d6",
                    SshPrivateKeyPath = @"C:\SFTP\ec_pharmacys_71d5851c_id_rsa.ppk",
                };

                using (Session session = new Session())
                {
                    session.ExecutablePath = @"C:\Program Files (x86)\WinSCP\WinSCP.exe";
                    
                    session.Open(sessionOptions);

                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
                    TransferOperationResult transferResult;
                    //This is for Getting/Downloading files from SFTP  
                    //transferResult = session.GetFiles(DirectoryPath, destinationFtpUrl, false, transferOptions);
                    //This is for Putting/Uploading file on SFTP  
                    transferResult = session.PutFiles(@"C:\SFTP\Send", @"\", false, transferOptions);
                    transferResult.Check();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
