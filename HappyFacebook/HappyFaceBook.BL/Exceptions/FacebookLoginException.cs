using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyFaceBook.BL.Exceptions
{
    /// <summary>
    /// Represents an exception while logging in to facebook
    /// </summary>
    public class FacebookLoginException : Exception
    {
        public FacebookLoginException()
        {
        }

        public FacebookLoginException(string message) : base(message)
        {
        }

        public FacebookLoginException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
