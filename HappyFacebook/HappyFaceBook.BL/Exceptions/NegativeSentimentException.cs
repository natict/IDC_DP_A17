using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyFaceBook.BL.Exceptions
{
    public class NegativeSentimentException: Exception
    {
        public NegativeSentimentException(string message): base($"post '{message}' is negative")
        {
                
        }
    }
}
