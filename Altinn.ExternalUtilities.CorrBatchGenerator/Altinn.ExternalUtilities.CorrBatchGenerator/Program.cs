using Altinn.Batch.Correspondence;

using Altinn.ExternalUtilities.CorrBatchGenerator.CommandLine;
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

            ////SftpClientHelper.TransferFiles();
        }
    }
}
