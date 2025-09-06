using AviUtlExoToAup2Converter.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    public static class DictionaryExtention
    {
        public static string Eval(this Dictionary<string, object> proxy, string operand)
        {
            XDocument doc = XDocument.Parse(operand);
            if (doc.Root == null) return string.Empty;

            XElement? elem = doc.Root.Element("var");
            if (elem == null)
            {
                return doc.Root.Value;
            }
            else
            {
                XAttribute? attr = elem.Attribute("name");
                if (attr == null) return string.Empty;

                object obj = proxy[attr.Value];
                string prop = elem.Value;
                Type type = obj.GetType();
                PropertyInfo? propInfo = type.GetProperty(prop);
                if (propInfo == null) return string.Empty;

                object? objValue = propInfo.GetValue(obj);
                if (objValue == null) return string.Empty;

                return (string)objValue;
            }
        }

        public static T GetValue<T>(this Dictionary<string, object> proxy, string from) where T : struct
        {
            XDocument doc = XDocument.Parse(from);
            if (doc.Root == null) return default;

            XAttribute? attr = doc.Root.Attribute("proxy");
            if (attr == null)
            {
                try
                {
                    return (T)System.Convert.ChangeType(doc.Root.Value, typeof(T));
                }
                catch
                {
                    return default;
                }
            }
            else
            {
                object obj = proxy[attr.Value];
                Type type = obj.GetType();
                PropertyInfo? propInfo = type.GetProperty("Attribute");
                if (propInfo == null) return default;

                object? objValue = propInfo.GetValue(obj);
                if (objValue == null) return default;

                return ((IAttribute[])objValue).GetValue<T>(from);
            }
        }

        public static string GetStringValue(this Dictionary<string, object> proxy, string from)
        {
            XDocument doc = XDocument.Parse(from);
            if (doc.Root == null) return string.Empty;

            XAttribute? attr = doc.Root.Attribute("proxy");
            if (attr == null)
            {
                return doc.Root.Value;
            }
            else
            {
                object obj = proxy[attr.Value];
                Type type = obj.GetType();
                PropertyInfo? propInfo = type.GetProperty("Attribute");
                if (propInfo == null) return string.Empty;

                object? objValue = propInfo.GetValue(obj);
                if (objValue == null) return string.Empty;

                return ((IAttribute[])objValue).GetValue<string>(from);
            }
        }
    }
}
