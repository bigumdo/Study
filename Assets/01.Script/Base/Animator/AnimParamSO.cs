using UnityEngine;

[CreateAssetMenu(menuName ="SO/Anim/ParamSO")]
public class AnimParamSO : ScriptableObject
{
    public enum AnimType
    {
        Boolean, Float, Integer, Trigger
    }

    public string paramName;
    public AnimType paramType;
    public int hashValue;

    //�ν����� �ٲ� �� ���� �����
    public void OnValidate()
    {
        hashValue = Animator.StringToHash(paramName);
    }
}
