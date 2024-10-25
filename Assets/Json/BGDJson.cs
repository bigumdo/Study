using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public static class BGDJson
{

    private static string jsonPath = Application.dataPath + "/JsonFolder/";

    private static void CreateFolder()
    {
        if(!Directory.Exists(jsonPath))
        {
            Debug.Log("폴더 없음");
            Directory.CreateDirectory(jsonPath);
            Debug.Log(jsonPath + " 위치에 폴더 생성");
            
        }
    }

    public static void ToJson<T>(T type,string name, bool s)
    {
        string jsonData = JsonUtility.ToJson(type, s);
        string path = Path.Combine(jsonPath, name + ".json");
        File.WriteAllText(path, jsonData);
    }

    public static T FromJson<T>(string name)
    {
        string path = Path.Combine(jsonPath, name + ".json");
        string data =  File.ReadAllText(path);
        return JsonUtility.FromJson<T>(data);
    }

    public static void ListToJson<T>(T type,string name)
    {
        FileStream stream = new FileStream(Path.Combine(jsonPath, name + ".json"), FileMode.Truncate);
        string jsonData = JsonConvert.SerializeObject(type, Formatting.Indented);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        stream.Write(data, 0, data.Length);
        stream.Close();
    }

    public static T ListFromJson<T>(string name)
    {
        FileStream stream = new FileStream(Path.Combine(jsonPath, name + ".json"), FileMode.Open);
        byte[] data = new byte[stream.Length];
        stream.Read(data, 0, data.Length);
        stream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonConvert.DeserializeObject<T>(jsonData);
        
    }

}
