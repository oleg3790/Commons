using System.IO;
using System.Net;
using System.Xml;

namespace Commons
{
    public class SoapRequestHelper
    {
        private static string _envelope = "<soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' {0}><soap:Header></soap:Header><soap:Body></soap:Body></soap:Envelope>";

        public XmlDocument BuildSoapEnvelope( string namespacePrefix, string namespaceUrl )
        {
            string ns = string.Format(@"xmlns:{0}='{1}'", namespacePrefix, namespaceUrl);
            string env = string.Format(_envelope, ns);

            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(env);

            return soapEnvelopeXml;
        }

        public HttpWebRequest BuildWebRequest( string url, string action )
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        public void InsertSoapEnvelopeIntoWebRequest( XmlDocument soapEnvelopeXml, HttpWebRequest webRequest )
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
