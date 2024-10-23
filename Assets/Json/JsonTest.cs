
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

[System.Serializable]
public class Data
{
    public string name;
    public int age;

}

public class Data2
{
    public Vector3 vec;
}



public class JsonTest : MonoBehaviour
{

    private void Start()
    {
        Data data = new Data();
        
        //Vector�� GameObject�� Component�� Json���� ������ϸ� �ڱ� ���� �����߻�
        // DataŬ������ json���Ϸ� ��������� SerializeObject���
        //string jsonData = JsonConvert.SerializeObject(data);
        //// Json���Ϸ� ����� �ٽ� �������� ����DeserializeObject���
        //Data data2 = JsonConvert.DeserializeObject<Data>(jsonData);

        //JsonUtility ���� �⺻���� ������ Ÿ�� ���� �迭 ����Ʈ�� ���� system.serialize�� ��߸� �������� Ŭ������ json���� ���� �� �ִ�.
        GameObject g1 = new GameObject();
        g1.AddComponent<Test>();
        g1.GetComponent<Test>().vec += Vector3.one;
        string jsonTest = JsonUtility.ToJson(g1.GetComponent<Test>());
        Debug.Log(jsonTest);

        GameObject g2 = new GameObject();
        g2.AddComponent<Test>();
        JsonUtility.FromJsonOverwrite(jsonTest, g2.GetComponent<Test>());
        Debug.Log(g2.GetComponent<Test>().vec);

    }


    //�ν����Ϳ� �ڵ帱 ���� ��ų �� �ְ� ���ش�.
    //[ContextMenu("To Json Data")]
    //void SaveJsonData()
    //{
    //    string jsonData = JsonUtility.ToJson(data,true);
    //    //Path.Combine ��� ǥ�ð� \ �� �ƴ� ���� �ֱ⿡ �����ϰ� Path.Combine ��� Application.dataPath ���� ����Ƽ ������Ʈ ��θ� �����´�.
    //    string path = Path.Combine(Application.dataPath, "playerData.json");
    //    File.WriteAllText(path, jsonData);
    //}

    //[ContextMenu("From Json Data")]
    //void LoadJsonData()
    //{
    //    string path = Path.Combine(Application.dataPath, "playerData.json");
    //    string jsonData = File.ReadAllText(path);
    //    data = JsonUtility.FromJson<Data>(jsonData);
}

