using UnityEngine;

[CreateAssetMenu(fileName = "StateSO", menuName = "SO/FSM/StateSO")]
public class StateSO : ScriptableObject
{
    public FSMState stateName;
    public string className;
    public AnimParamSO animParam;
}
