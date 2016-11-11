using Altinn.Batch.Correspondence;
using Altinn.ExternalUtilities.CorrBatchGenerator.CommandLine;
using Altinn.ExternalUtilities.CorrBatchGenerator.Utils;

namespace Altinn.ExternalUtilities.CorrBatchGenerator
{
    /// <summary>
    /// Console program class.
    /// </summary>
    public class Program : AltinnConsole<CorrBatchGeneratorArguments>
    {
        /// <summary>
        /// Console program start method.
        /// </summary>
        /// <param name="args">Console arguments.</param>
        public static void Main(string[] args)
        {
            Correspondences cors = new Correspondences();            

            Run<Program>(args);

            //SftpClientHelper.TransferFiles();
        }

        protected override void Execute()
        {
        }
    }
}
