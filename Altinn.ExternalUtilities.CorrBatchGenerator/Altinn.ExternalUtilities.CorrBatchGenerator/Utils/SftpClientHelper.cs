﻿using System;
using System.Configuration;
using WinSCP;

namespace Altinn.ExternalUtilities.CorrBatchGenerator.Utils
{
    /// <summary>
    /// Helper class for common operations related to SFTP.
    /// </summary>
    public class SftpClientHelper
    {
        /// <summary>
        /// Perform a SFTP transfer of files from a configured local folder to a configured remote folder.
        /// </summary>
        public static void TransferFiles()
        {
            try
            {
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = ConfigurationManager.AppSettings["ftpHostName"],
                    UserName = ConfigurationManager.AppSettings["ftpUserName"],
                    Password = ConfigurationManager.AppSettings["ftpPassword"],
                    GiveUpSecurityAndAcceptAnySshHostKey = true,
                    ////SshHostKeyFingerprint = ConfigurationManager.AppSettings["sshHostKeyFingerprint"]
                };

                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    // Upload files
                    TransferOptions transferOptions = new TransferOptions { TransferMode = TransferMode.Binary };

                    TransferOperationResult transferResult = session.PutFiles(ConfigurationManager.AppSettings["localPathToFilesToUpload"],
                                                                              ConfigurationManager.AppSettings["remotePath"], false, transferOptions);

                    // Throw on any error
                    transferResult.Check();

                    // Print results
                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
        }
    }
}
