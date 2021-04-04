using System;
using System.IO;
using System.Xml.Serialization;

namespace ProductShop.Utils
{
    public static class XMLCustomSerializer
    {
        public static T Deserialize<T>(string inputXml, string rootName)
        {
            var xmlRoot = new XmlRootAttribute(rootName);
            var serialazer = new XmlSerializer(typeof(T), xmlRoot);

            var textReader = new StringReader(inputXml);
            var usersDto = (T)serialazer.Deserialize(textReader);
            return usersDto;
        }

        public static string Serialize<T>(T dto, string rootName)
        {
            var xmlRoot = new XmlRootAttribute(rootName);
            var serializer = new XmlSerializer(typeof(T), xmlRoot);

            using (StringWriter stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, dto, GetXmlNamespace());
                return stringWriter.ToString();
            }
        }

        public static string Serialize<T>(T[] dto, string rootName)
        {
            var xmlRoot = new XmlRootAttribute(rootName);
            var serializer = new XmlSerializer(typeof(T[]), xmlRoot);

            using (StringWriter stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, dto, GetXmlNamespace());
                return stringWriter.ToString();
            }
        }

        private static XmlSerializerNamespaces GetXmlNamespace()
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            return namespaces;
        }
    }
}
