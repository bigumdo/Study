using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using System.Text;

public class JsonSaveFile : MonoBehaviour
{
    private void Start()
    {
        //FileStream stream = new FileStream(Path.Combine(Application.dataPath, "playerData.json"), FileMode.Truncate);
        //JsonDataTast test1 = new JsonDataTast();
        //test1.name = "A";
        //test1.age = 1;
        //test1.money = 2;
        //string jsonData = JsonConvert.SerializeObject(test1);
        //byte[] data = Encoding.UTF8.GetBytes(jsonData);
        //stream.Write(data, 0, data.Length);
        //stream.Close();

        //FileStream stream = new FileStream(Path.Combine(Application.dataPath, "playerData.json"), FileMode.Open);
        //byte[] data = new byte[stream.Length];
        //stream.Read(data, 0, data.Length);
        //stream.Close();
        //string jsonData = Encoding.UTF8.GetString(data);
        //Test test1 = JsonConvert.DeserializeObject<Test>(jsonData);
        //JsonUtility.FromJsonOverwrite()


    }

}
