using System;
using System.Runtime.Serialization;

namespace HappyFaceBook.BL.Exceptions
{
    [Serializable]
    internal class GiphyTranslateException : Exception
    {
        public GiphyTranslateException()
        {
        }

        public GiphyTranslateException(string message) : base(message)
        {
        }

        public GiphyTranslateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GiphyTranslateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}