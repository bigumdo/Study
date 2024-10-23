
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
        
        //Vector나 GameObject에 Component를 Json으로 만들려하면 자기 참조 루프발생
        // Data클래스를 json파일로 만들기위해 SerializeObject사용
        //string jsonData = JsonConvert.SerializeObject(data);
        //// Json파일로 만들걸 다시 돌려놓기 위해DeserializeObject사용
        //Data data2 = JsonConvert.DeserializeObject<Data>(jsonData);

        //JsonUtility 단점 기본적인 데이터 타입 변수 배열 리스트만 가능 system.serialize를 써야만 직접만든 클래스를 json으로 만들 수 있다.
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


    //인스펙터에 코드릴 실행 시킬 수 있게 해준다.
    //[ContextMenu("To Json Data")]
    //void SaveJsonData()
    //{
    //    string jsonData = JsonUtility.ToJson(data,true);
    //    //Path.Combine 경로 표시가 \ 가 아닐 수도 있기에 안전하게 Path.Combine 사용 Application.dataPath 현재 유니티 프로젝트 경로를 가져온다.
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

