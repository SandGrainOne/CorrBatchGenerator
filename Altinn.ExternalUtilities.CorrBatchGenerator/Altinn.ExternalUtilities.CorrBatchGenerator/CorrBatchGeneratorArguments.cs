using System.ComponentModel;

using Altinn.ExternalUtilities.CorrBatchGenerator.CommandLine;

namespace Altinn.ExternalUtilities.CorrBatchGenerator
{
    public class CorrBatchGeneratorArguments : ConsoleArguments
    {
        [Description("Control whether to create notifications.")]
        public bool CreateNotifications { get; set; }
    }
}
