

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        string filename = Application.persistentDataPath + "/" + path + ".xml";
        if (!System.IO.File.Exists(filename))
            Debug.Log("no se encuentran los archivos al serializar");

        XmlSerializer serializer = new XmlSerializer(item.GetType());
        FileStream stream = new FileStream(filename, FileMode.Create);

        XmlTextWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8);
        serializer.Serialize(xmlWriter, item);
        stream.Close();

    }
    public static void SerializarAResources(object item, string path)
    {
        string filename = "Assets/Resources/" + path + ".xml";
        if (!System.IO.File.Exists(filename))
            Debug.Log("no se encuentran los archivos al serializar");

        XmlSerializer serializer = new XmlSerializer(item.GetType());
        FileStream stream = new FileStream(filename, FileMode.Create);

        XmlTextWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8);
        serializer.Serialize(xmlWriter, item);

    }
    public static T DeserializarDesdeResources<T>(string path)
    {

        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StringReader reader = new StringReader(_xml.ToString());
        T obj = (T)serializer.Deserialize(reader);
        reader.Close();

        return obj;
    }
    public static T Deserializar<T>(string path)
    {

        /* // TextAsset _xml = File.ReadAllText(Application.persistentDataPath.ToString() + "/levelFile.xml") as TextAsset;
         StreamReader streamReader = File.OpenText(Application.persistentDataPath + "/" + path + ".xml");
         string entireText = streamReader.ReadToEnd();
         streamReader.Close();
         XmlSerializer serializer = new XmlSerializer(typeof(T));
         StringReader reader = new StringReader(streamReader.ToString());
         T obj = (T)serializer.Deserialize(reader);
         reader.Close();

         return obj;*/
        string filename = Application.persistentDataPath + "/" + path + ".xml";
        if (System.IO.File.Exists(filename))
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            TextReader reader = new StreamReader(filename);
            T obj = (T)deserializer.Deserialize(reader);

            reader.Close();
            return obj;

        }
        else
        {
            TextAsset _xml = Resources.Load<TextAsset>(path);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(_xml.ToString());
            T obj = (T)serializer.Deserialize(reader);
            reader.Close();

            return obj;
        }


    }
}



