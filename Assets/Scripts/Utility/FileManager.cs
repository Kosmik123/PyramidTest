using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


public static class FileManager
{
    public static void WriteSaveFile(string contents, string filepath)
    {
        File.WriteAllText(filepath, contents);
    }

    public static void WriteSaveFile<T>(T data, string filepath)
    {
        FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            Debug.Log("Serializing " + filepath);
            formatter.Serialize(fs, data);
        }
        catch (SerializationException e)
        {
            Debug.LogError("Save failded! " + e);
            throw;
        }
        finally
        {
            fs.Close();
        }
    }

    public static string ReadSaveFileAsString(string filepath)
    {
        if (File.Exists(filepath))
        {
            return File.ReadAllText(filepath);
        }
        return "";
    }

    public static T ReadSaveFile<T>(string filepath)
    {
        FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
        BinaryFormatter formatter = new BinaryFormatter();
        T data = default;

        try
        {
            data = (T)formatter.Deserialize(fs);
        }
        catch (SerializationException e)
        {
            Debug.LogWarning("Loading error! " + e);
        }
        finally
        {
            fs.Close();
        }

        return data;
    }

    public static bool Exists(string filepath)
    {
        return Directory.Exists(filepath);
    }

}
