using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public abstract class PersistentHighScore : ScriptableObject
{
    public void Save(string fileName = null)
    {
        var bf = new BinaryFormatter();
        var file = File.Create(GetRoute(fileName));
        var json = JsonUtility.ToJson(this);
        bf.Serialize(file, json);
        file.Close();
    }

    public virtual void Load(string fileName = null)
    {
        if (File.Exists(fileName))
        {
            var bf = new BinaryFormatter();
            var file = File.Open(GetRoute(fileName),FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), this);
            file.Close();
        }
    }

    public string GetRoute(string fileName = null)
    {
        var fullFileName = string.IsNullOrEmpty(fileName) ? name : fileName;
        return string.Format("{0}/{1}.breakout", Application.persistentDataPath, fullFileName);
    }
}
