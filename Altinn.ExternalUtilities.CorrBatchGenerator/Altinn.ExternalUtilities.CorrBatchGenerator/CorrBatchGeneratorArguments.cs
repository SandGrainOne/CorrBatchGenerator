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
    }
}
