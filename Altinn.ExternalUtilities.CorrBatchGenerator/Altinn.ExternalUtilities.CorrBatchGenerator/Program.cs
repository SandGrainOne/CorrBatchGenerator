using Altinn.ExternalUtilities.CorrBatchGenerator.CommandLine;

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

        protected override void Execute()
        {
        }
    }
}
