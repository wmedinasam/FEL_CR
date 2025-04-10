using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace DTECore
{
    public static class Methods
    {
        public static string SerializeObjectToXML(ECF documento) 
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ECF));
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                OmitXmlDeclaration = false,
            };

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(false)))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter, settings))
                    {
                        serializer.Serialize(xmlWriter, documento);
                    }
                }
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
    }
}
