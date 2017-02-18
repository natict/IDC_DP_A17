using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyFaceBook.BL;

namespace HappyFaceBook.UI.PostHandlers
{
    /// <summary>
    /// Textual post sentiment analyzer
    /// </summary>
    public class SentimentPostHandler : PostHandlerBase
    {
        private ISentimentClient m_SentimentClient;

        public SentimentPostHandler(ISentimentClient i_SentimentClient)
        {
            m_SentimentClient = i_SentimentClient;
        }

        protected override async Task<bool> HandleRequest(PostRequest request)
        {
            if (request.ShouldStayPositive)
            {
                eSentiment sentiment = m_SentimentClient.GetSentiment(request.Message);
                if (sentiment == eSentiment.Negative)
                {
                    request.RequestResult = "Be more positive and try again!";
                    return false;
                }
            }

            return true;
        }
    }
}
