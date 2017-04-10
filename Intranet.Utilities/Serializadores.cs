using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Intranet.Utilities
{
    public static class Serializadores
    {
        //Serializar a XML (UTF-16) un objeto cualquiera
        public static string SerializarToXml(this object obj)
        {
            try
            {
                StringWriter strWriter = new StringWriter();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());

                serializer.Serialize(strWriter, obj);
                string resultXml = strWriter.ToString();
                strWriter.Close();

                return resultXml;
            }
            catch
            {
                return string.Empty;
            }
        }

        //Deserializar un XML a un objeto T
        public static T DeserializarTo<T>(this string xmlSerializado)
        {
            try
            {
                xmlSerializado.Replace('\"',' ');
                XmlSerializer xmlSerz = new XmlSerializer(typeof(T));

                using (StringReader strReader = new StringReader(xmlSerializado))
                {
                    object obj = xmlSerz.Deserialize(strReader);
                    return (T)obj;
                }
            }
            catch { return default(T); }
        }
    }
}
