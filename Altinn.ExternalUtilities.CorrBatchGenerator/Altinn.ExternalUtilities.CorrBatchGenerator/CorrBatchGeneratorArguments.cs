using System.ComponentModel;

using Altinn.ExternalUtilities.CorrBatchGenerator.CommandLine;

namespace Altinn.ExternalUtilities.CorrBatchGenerator
{
    /// <summary>
    /// Console arguments for the correspondence batch generator tool.
    /// </summary>
    public class CorrBatchGeneratorArguments : ConsoleArguments
    {
        /// <summary>
        /// Gets or sets a value indicating whether the tool should add notifications.
        /// </summary>
        [Description("Control whether to create notifications.")]
        public bool CreateNotifications { get; set; }

        /// <summary>
        /// Gets or sets the path and name of an input file.
        /// </summary>
        [Description("The input csv file containing correspondence rows")]
        public string SourceFile { get; set; }

        [Description("The Service Code for all Correspondences of the source file")]
        public string ServiceCode { get; set; }

        [Description("The Service Edition for all correspondences of the source file")]
        public string ServiceEdition { get; set; }
    }
}
