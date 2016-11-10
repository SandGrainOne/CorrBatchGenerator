using System.Collections.Generic;
using System.Reflection;

namespace Altinn.ExternalUtilities.CorrBatchGenerator.CommandLine
{
    /// <summary>
    /// Dumb data structure representing command line arguments and metadata.
    /// </summary>
    /// <typeparam name="TArguments">
    /// The type that represents the command-line arguments.
    /// </typeparam>
    internal class ArgumentInfo<TArguments>
        where TArguments : ConsoleArguments, new()
    {
        /// <summary>
        /// Gets or sets arguments
        /// </summary>
        public TArguments Arguments { get; set; } = new TArguments();

        /// <summary>
        /// Gets or sets error messages
        /// </summary>
        public List<string> ErrorMessages { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets unassigned properties
        /// Keeps track of properties that have not been assigned. All properties should be assigned, either
        /// explicitly stated on the command line, or via a default value (declared with DefaultValue attribute).
        /// </summary>
        public List<PropertyInfo> UnassignedProperties { get; set; } = new List<PropertyInfo>(typeof(TArguments).GetProperties());

        /// <summary>
        /// Gets or sets Warning messages
        /// </summary>
        public List<string> WarningMessages { get; set; } = new List<string>();
    }
}