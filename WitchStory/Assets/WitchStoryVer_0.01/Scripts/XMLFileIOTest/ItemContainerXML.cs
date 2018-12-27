using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Text;
using System.Xml.Serialization;

[XmlRoot("ItemCollection")]
public class ItemContainerXML
{
    [XmlArray("Items"), XmlArrayItem("Item")]
    public List<ItemXML> items = new List<ItemXML>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(ItemContainerXML));
        using (var stream = new StreamWriter(new FileStream(path, FileMode.Create), Encoding.UTF8))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static ItemContainerXML Load(string path)
    {
        var serializer = new XmlSerializer(typeof(ItemContainerXML));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as ItemContainerXML;
        }
    }

    public static ItemContainerXML LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(ItemContainerXML));
        return serializer.Deserialize(new StringReader(text)) as ItemContainerXML;
    }
}
