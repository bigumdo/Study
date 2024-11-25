using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FSMState
{
    Idle, Move, Attack,
    Jump, Fall, Dash,
    JumpAttack, DashAttack, React
}

public class AgentStateListSO : ScriptableObject
{
    [CreateAssetMenu(menuName = "SO/FSM/AgentStateListSO")]
    public class EntityStateListSO : ScriptableObject
    {
        public List<StateSO> states;
    }
}
