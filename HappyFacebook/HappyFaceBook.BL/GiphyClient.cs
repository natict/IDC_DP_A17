using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using HappyFaceBook.BL.Exceptions;

namespace HappyFaceBook.BL
{
    public class GiphyClient
    {
        
        private readonly string r_BaseTranslateURL = "http://api.giphy.com/v1/gifs/translate";
        private const string k_ApiKey = "dc6zaTOxFJmzC";

        public string Translate(string text)
        {
            string imageUrl = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getTranslateURL(text));
                request.Method = WebRequestMethods.Http.Get;

                // Get the stream associated with the response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();

                // For that you will need to add reference to System.Runtime.Serialization
                XmlDictionaryReader jsonReader = JsonReaderWriterFactory.CreateJsonReader(receiveStream, new XmlDictionaryReaderQuotas());
                XElement root = XElement.Load(jsonReader);

                imageUrl = root.XPathSelectElement("//data/images/original/url").Value;
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

        private string getTranslateURL(string text)
        {
            UriBuilder translateURL = new UriBuilder(r_BaseTranslateURL);
            translateURL.Query = string.Join("&", String.Format("s={0}", text), String.Format("api_key={0}", k_ApiKey));
            return translateURL.ToString();
        }
    }
}
