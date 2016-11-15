using System;

namespace Altinn.ExternalUtilities.CorrBatchGenerator.Exceptions
{
    /// <summary>
    /// Data source reader exception
    /// </summary>
    [Serializable]
    public class DatasourceReaderException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatasourceReaderException"/> class
        /// </summary>
        public DatasourceReaderException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatasourceReaderException"/> class given a message
        /// </summary>
        /// <param name="message">The exception message</param>
        public DatasourceReaderException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatasourceReaderException"/> class given a message and inner exception
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="inner">The inner exception</param>
        public DatasourceReaderException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatasourceReaderException"/> class given serialization info
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DatasourceReaderException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}
