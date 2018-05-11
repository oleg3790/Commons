using System;
using System.Text;
using System.Xml;

namespace Commons
{
    public static class XmlHelper
    {
        public static string FormatXml( string xmlData )
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
    }
}
