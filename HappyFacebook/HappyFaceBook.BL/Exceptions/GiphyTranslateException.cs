using System;

namespace HappyFaceBook.BL.Exceptions
{
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
    }
}