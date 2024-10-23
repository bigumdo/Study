using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class JsonDataTast
{
    public string name;
    public int age;
    public int money;
}

public class Test : MonoBehaviour
{
    private void Start()
    {
        JsonDataTast data1 = new JsonDataTast();
        data1.name = "aa";
        data1.age = 10;
        data1.money = 20;
        JsonDataTast data2 = new JsonDataTast();
        BGDJson.ToJson(data1, "Test", true);
        data2 = BGDJson.FromJson(data1, "Test");

        Debug.Log(data2.name);
        Debug.Log(data2.age);
        Debug.Log(data2.money);

    }
}
