using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class XMLManager
{

    public XMLManager()
    {
    }
    public static void Serializar(object item, string path)
    {
        XmlSerializer serializer = new XmlSerializer(item.GetType());
        StreamWriter writer = new StreamWriter(path);
        serializer.Serialize(writer.BaseStream, item);
        writer.Close();

    }

    public static T Deserializar<T>(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StringReader reader = new StringReader(_xml.ToString());
        T obj = (T)serializer.Deserialize(reader);
        reader.Close();

        return obj;
    }
}

