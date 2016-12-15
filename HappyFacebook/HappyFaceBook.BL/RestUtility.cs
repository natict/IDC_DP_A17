using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace HappyFaceBook.BL
{
    public static class RestUtility
    {
        // HTTP GET an i_Url, and extract an i_XPath from the returned json
        public static string getResponseXPath(string i_Url, string i_XPath)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(i_Url);
            request.Method = WebRequestMethods.Http.Get;

            // Get the stream associated with the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();

            // For that you will need to add reference to System.Runtime.Serialization
            XmlDictionaryReader jsonReader = JsonReaderWriterFactory.CreateJsonReader(receiveStream, new XmlDictionaryReaderQuotas());
            XElement root = XElement.Load(jsonReader);

            return root.XPathSelectElement(i_XPath).Value;
        }
    }
}
