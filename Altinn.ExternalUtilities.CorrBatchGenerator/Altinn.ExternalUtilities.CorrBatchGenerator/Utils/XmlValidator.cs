using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace Altinn.ExternalUtilities.CorrBatchGenerator.Utils
{
    /// <summary>
    /// Helper class for validating an XML versus Schema
    /// </summary>
    public static class XmlValidator
    {
        /// <summary>
        /// Validates and XML against the correspondence Schema and throws any Exception when not validated.
        /// </summary>
        /// <param name="xmlFilePath">The XML file path</param>
        public static void Validate(string xmlFilePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Schemas.Add("http://schemas.altinn.no/services/intermediary/correspondence/2009/10", 
                @"Schema\schemas.altinn.no.services.intermediary.correspondence.2016.02.xsd");
            doc.LoadXml(File.ReadAllText(xmlFilePath));
            doc.Validate(XmlValidationEventHandler);
        }

        /// <summary>
        /// XML Validation EventHandler
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">validation event argument</param>
        private static void XmlValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Warning:
                    throw new XmlSchemaValidationException(e.Message);
                case XmlSeverityType.Error:
                    throw new XmlSchemaValidationException(e.Message);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
