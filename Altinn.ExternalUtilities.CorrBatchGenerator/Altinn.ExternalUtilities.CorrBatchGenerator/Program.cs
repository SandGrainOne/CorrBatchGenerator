using System;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Altinn.Batch.Correspondence;

using Altinn.ExternalUtilities.CorrBatchGenerator.CommandLine;
using Altinn.ExternalUtilities.CorrBatchGenerator.Entities;
using Altinn.ExternalUtilities.CorrBatchGenerator.Utils;

namespace Altinn.ExternalUtilities.CorrBatchGenerator
{
    /// <summary>
    /// Console program class.
    /// </summary>
    public class Program : ConsoleBase<CorrBatchGeneratorArguments>
    {
        /// <summary>
        /// Console program start method.
        /// </summary>
        /// <param name="args">Console arguments.</param>
        public static void Main(string[] args)
        {
            Run<Program>(args);
        }

        /// <summary>
        /// Start of console application specific logic.
        /// </summary>
        protected override void Execute()
        {
            // This is where magic happens

            // Fetch datasett fra en kommaseparert fil, der hver linje er en correspondence
            DatasourceReader reader = new DatasourceReader(this.Arguments.SourceFile);
            reader.ReadFile();

            Correspondences corrColl = new Correspondences()
            {
                SystemUserCode = ConfigurationManager.AppSettings["systemUserCode"],
                ShipmentReference = Guid.NewGuid().ToString(),
                SequenceNo = null,
                Correspondence = new CorrespondencesCorrespondence[reader.Count]
            };

            int index = 0;
            // For datasettet lages en XML fil med alle correspence fra csv fila
            // systemUserCode hentes fra app.config
            foreach (CorrespondenceInput correspondence in reader.GetEnumerable())
            {
                corrColl.Correspondence[index++] = new CorrespondencesCorrespondence()
                {
                    Reportee = correspondence.Reportee,
                    ServiceCode = this.Arguments.ServiceCode,
                    ServiceEdition = this.Arguments.ServiceEdition,
                    SendersReference = Guid.NewGuid().ToString(),
                    Content = new CorrespondencesCorrespondenceContent()
                    {
                        LanguageCode = correspondence.LanguageCode,
                        MessageTitle = correspondence.MessageTitle,
                    }
                };
            }

            string destfolder = ConfigurationManager.AppSettings["localPathToFilesToUpload"];
            string name = Path.GetFileName(this.Arguments.SourceFile);
            if (name == null)
            {
                return;
            }

            string fileName = name.Replace(".csv", ".xml");
            string destfile = destfolder.Contains("*")
                ? destfolder.Replace("*", fileName)
                : Path.Combine(destfolder, fileName);

            // XML filene lagres på local path ihht konfigurasjonen localPathToFilesToUpload
            using (FileStream fileStream = File.Create(destfile))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(corrColl.GetType());
                serializer.Serialize(fileStream, corrColl);
            }

            ////SftpClientHelper.TransferFiles();
        }
    }
}
