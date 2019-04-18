using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XApp.Commons
{
    public static class XmlHelper
    {
        public static string FormatXml(string xmlData)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlData);
                StringBuilder sb = new StringBuilder();
                System.IO.TextWriter tr = new System.IO.StringWriter(sb);
                XmlTextWriter wr = new XmlTextWriter(tr);
                wr.Formatting = Formatting.Indented;
                doc.Save(wr);
                wr.Close();
                return sb.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static XmlElement SerializeToXmlElement(object obj, XmlSerializerNamespaces ns)
        {
            XmlDocument doc = new XmlDocument();

            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(obj.GetType()).Serialize(writer, obj, ns);
            }
            return doc.DocumentElement;
        }

        public static XmlDocument SerializeToXmlDocument(object input, string namespaceUri)
        {
            XmlSerializer ser = new XmlSerializer(input.GetType(), namespaceUri);

            XmlDocument doc = null;

            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, input);

                memStm.Position = 0;

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                using (var xtr = XmlReader.Create(memStm, settings))
                {
                    doc = new XmlDocument();
                    doc.Load(xtr);
                }
            }
            return doc;
        }
    }
}
