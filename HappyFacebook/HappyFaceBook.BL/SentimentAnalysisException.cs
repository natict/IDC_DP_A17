using System;
using System.Runtime.Serialization;

namespace HappyFaceBook.BL
{
    [Serializable]
    internal class SentimentAnalysisException : Exception
    {
        public SentimentAnalysisException()
        {
        }

        public SentimentAnalysisException(string message) : base(message)
        {
        }

        public SentimentAnalysisException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SentimentAnalysisException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}