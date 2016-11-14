using System;

namespace Altinn.ExternalUtilities.CorrBatchGenerator.Exceptions
{
    [Serializable]
    public class DatasourceReaderException : Exception
    {
        public DatasourceReaderException()
        {
        }

        public DatasourceReaderException(string message) : base(message)
        {
        }

        public DatasourceReaderException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DatasourceReaderException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}
