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

    //¿ŒΩ∫∆Â≈Õ πŸ≤ ∂ß ∏∂¥Ÿ Ω««‡µ 
    public void OnValidate()
    {
        hashValue = Animator.StringToHash(paramName);
    }
}
