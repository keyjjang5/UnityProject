using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class DataManager
{
    public static void BinarySerialize<T>(T t ,string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(/*이부분은 임의로 설정한 경로Define.DataFilePath*/"Assets/Resources/DataSave/" + filePath, FileMode.OpenOrCreate);
        formatter.Serialize(stream, t);
        stream.Close();
    }

    public static T BinaryDeserialize<T>(string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(/*Define.DataFilePath*/"Assets/Resources/DataSave/" + filePath, FileMode.Open);
        T t = (T)formatter.Deserialize(stream);
        stream.Close();

        return t;
    }
}