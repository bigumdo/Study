using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class JsonDataTast
{
    public string name;
    public int age;
    public int money;
    public List<string> data;
    public Dictionary<string, string> tags = new Dictionary<string, string>();
    public JsonDataTast(List<string> list)
    {
        tags.Add("Test", "OK");
        data = list;
    }
}

public class Test : MonoBehaviour
{

    [ContextMenu("TestJson")]
    public void TestMethod()
    {
        List<string> list = new List<string>();
        list.Add("Test1");
        list.Add("Test2");
        list.Add("Test3");
        list.Add("Test4");
        list.Add("Test5");
        list.Add("Test6");
        JsonDataTast jsontest = new JsonDataTast(list);

        BGDJson.ListToJson(jsontest, "AA");
        List<string> list2 = new List<string>();
        JsonDataTast test;
        test = BGDJson.ListFromJson<JsonDataTast>("AA");
        foreach (var item in test.data)
        {
            Debug.Log(item);
        }

    }

    [ContextMenu("TestJson2")]
    public void TestMethod2()
    {
        List<string> list = new List<string>();
        list.Add("Test21");
        list.Add("Test22");
        list.Add("Test23");
        BGDJson.ListToJson(list, "AA");
        List<string> list2 = new List<string>();
        list2 = BGDJson.ListFromJson<List<string>>("AA");
        foreach(var item in list2)
        {
            Debug.Log(item);
        }
    }

    private void Start()
    {

        

        //JsonDataTast data1 = new JsonDataTast();
        //data1.name = "aa";
        //data1.age = 10;
        //data1.money = 20;
        //JsonDataTast data2 = new JsonDataTast();
        //BGDJson.ToJson(data1, "Test", true);
        //data2 = BGDJson.FromJson(data1, "Test");

        //Debug.Log(data2.name);
        //Debug.Log(data2.age);
        //Debug.Log(data2.money);

    }
}
