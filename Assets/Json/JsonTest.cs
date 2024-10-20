
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Data
{
    public string name;
    public int age;

}


public class JsonTest : MonoBehaviour
{
    public Data data;

    //�ν����Ϳ� �ڵ帱 ���� ��ų �� �ְ� ���ش�.
    [ContextMenu("To Json Data")]
    void SaveJsonData()
    {
        string jsonData = JsonUtility.ToJson(data,true);
        //Path.Combine ��� ǥ�ð� \ �� �ƴ� ���� �ֱ⿡ �����ϰ� Path.Combine ��� Application.dataPath ���� ����Ƽ ������Ʈ ��θ� �����´�.
        string path = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadJsonData()
    {
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        data = JsonUtility.FromJson<Data>(jsonData);
    }
}
