using System;

namespace HappyFaceBook.BL.Exceptions
{
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
    }
}