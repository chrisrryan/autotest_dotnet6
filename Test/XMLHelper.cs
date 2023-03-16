using System.Xml.Serialization;

namespace autotest.Test;
public static class XmlHelper
{
    public static T FromXml<T>(this string value)
    {
        using TextReader reader = new StringReader(value);
        return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
    }
}
