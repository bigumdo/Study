using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

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

    public static T FromJson<T>(T type, string name)
    {
        string path = Path.Combine(jsonPath, name + ".json");
        string data =  File.ReadAllText(path);
        return JsonUtility.FromJson<T>(data);
    }

}
