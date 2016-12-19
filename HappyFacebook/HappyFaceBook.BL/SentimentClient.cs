using System;
using System.Web;
using HappyFaceBook.BL.Exceptions;

namespace HappyFaceBook.BL
{
    public class SentimentClient: ISentimentClient
    {
        private const string k_DemoApiKey = "da568b9d617a4d36a757e0c5b3fab9a9";
        private const string k_SenitimentAnalysisUrl = "https://api.dandelion.eu/datatxt/sent/v1";
        private const string k_SentimentXPath = "//sentiment/type";

        private readonly string r_ApiKey = k_DemoApiKey;

        public SentimentClient()
        {
        }

        public SentimentClient(string i_ApiKey)
        {
            r_ApiKey = i_ApiKey;
        }

        public eSentiment GetSentiment(string i_Text)
        {
            eSentiment sentiment;
            try
            {
                switch (RestUtility.GetResponseXPath(generateSentimentURL(i_Text), k_SentimentXPath))
                {
                    case "positive":
                        sentiment = eSentiment.Positive;
                        break;
                    case "negative":
                        sentiment = eSentiment.Negative;
                        break;
                    case "neutral":
                    default:
                        sentiment = eSentiment.Neutral;
                        break;
                }
            }
            catch (Exception Ex)
            {
                throw new SentimentAnalysisException("unable to get Sentiment Analysis from Dandelion", Ex);
            }

            return sentiment;
        }

        private string generateSentimentURL(string i_Text)
        {
            UriBuilder sentimentURL = new UriBuilder(k_SenitimentAnalysisUrl);
            sentimentURL.Query = string.Join("&", string.Format("text={0}", HttpUtility.UrlEncode(i_Text)), string.Format("token={0}", r_ApiKey), "lang=en");
            return sentimentURL.ToString();
        }
    }
}
