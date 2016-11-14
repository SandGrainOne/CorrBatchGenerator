namespace Altinn.ExternalUtilities.CorrBatchGenerator.Entities
{
    /// <summary>
    /// Represents data used as input when creating a correspondence
    /// </summary>
    public class CorrespondenceInput
    {
        /// <summary>
        /// Gets or sets the recipient of the correspondence. Social security number, 
        /// organization number or self identified user.
        /// </summary>
        public string Reportee { get; set; }

        /// <summary>
        /// Gets or sets the language code for the correspondence
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Gets or sets the message title 
        /// </summary>
        public string MessageTitle { get; set; }
    }
}
