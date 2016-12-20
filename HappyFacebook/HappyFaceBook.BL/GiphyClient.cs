using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using System.Web;
using HappyFaceBook.BL.Exceptions;

namespace HappyFaceBook.BL
{
    public class GiphyClient : IGiphyClient
    {
        private const string k_DemoApiKey = "dc6zaTOxFJmzC";
        private const string k_ImageUrlXPath = "//data/images/original/url";
        private const string k_BaseTranslateURL = "http://api.giphy.com/v1/gifs/translate";

        private readonly string r_ApiKey = k_DemoApiKey;

        public GiphyClient(string i_ApiKey)
        {
            r_ApiKey = i_ApiKey;
        }

        public GiphyClient()
        {
        }

        public string Translate(string i_Text)
        {
            string imageUrl = null;
            try
            {
                imageUrl = RestUtility.GetResponseXPath(generateTranslateURL(i_Text), k_ImageUrlXPath);
            }
            catch (Exception Ex)
            {
                throw new GiphyTranslateException("unable to fetch gif from Giphy", Ex);
            }

            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new GiphyTranslateException("got an empty response from Giphy");
            }
            
            return imageUrl;
        }

        private string generateTranslateURL(string i_Text)
        {
            UriBuilder translateURL = new UriBuilder(k_BaseTranslateURL);
            translateURL.Query = string.Join("&", string.Format("s={0}", HttpUtility.UrlEncode(i_Text)), string.Format("api_key={0}", r_ApiKey));
            return translateURL.ToString();
        }
    }
}
