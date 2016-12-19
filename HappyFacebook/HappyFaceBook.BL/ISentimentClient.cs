using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyFaceBook.BL
{
    public interface ISentimentClient
    {
        eSentiment GetSentiment(string i_Text);
    }
}
