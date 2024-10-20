
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

    //인스펙터에 코드릴 실행 시킬 수 있게 해준다.
    [ContextMenu("To Json Data")]
    void SaveJsonData()
    {
        string jsonData = JsonUtility.ToJson(data,true);
        //Path.Combine 경로 표시가 \ 가 아닐 수도 있기에 안전하게 Path.Combine 사용 Application.dataPath 현재 유니티 프로젝트 경로를 가져온다.
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
