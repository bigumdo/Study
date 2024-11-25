using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class AgentStat : MonoBehaviour, IAgentComponent
{
    [Header("Frequently used Stat")]
    [SerializeField] private StatSO _hpStat;
    [SerializeField] private StatSO _moveSpeed;

    [Space]
    [SerializeField] private StatOverride[] _statOverrides;
    private StatSO[] _stats; //this is real stat
    public Agent Owner { get; private set; }
    public StatSO HpStat { get; private set; }
    public StatSO MoveSpeedStat { get; private set; }

    public void Initialize(Agent agent)
    {
        Owner = agent;

        //���� �������̵� �� ���־��� ������ �̾Ƽ� �����صд�.
        _stats = _statOverrides.Select(x => x.CreateStat()).ToArray();
        HpStat = _hpStat ? GetStat(_hpStat) : null;
        MoveSpeedStat = _moveSpeed ? GetStat(_moveSpeed) : null;
    }

    public StatSO GetStat(StatSO stat)
    {
        //���ڰ� False�� �����޽����� ������
        Debug.Assert(stat != null, $"Stats::Getstat- stat�� null�� �� �����ϴ�.");
        return _stats.FirstOrDefault(x => x.statName == stat.statName);
    }

    public bool TryGetStat(StatSO stat, out StatSO outStat)
    {
        Debug.Assert(stat != null, $"Stats::TryGetstat- stat�� null�� �� �����ϴ�.");

        outStat = _stats.FirstOrDefault(x => x.statName == stat.statName);
        return outStat != null;
    }


    public void SetBaseValue(StatSO stat, float value)
        => GetStat(stat).BaseValue = value;

    public float GetBaseValue(StatSO stat)
        => GetStat(stat).BaseValue;

    public void IncreaseBaseValue(StatSO stat, float value)
        => GetStat(stat).BaseValue += value;

    public void AddModifier(StatSO stat, string key, float value)
        => GetStat(stat).AddModifier(key, value);
    public void RemoveModifier(StatSO stat, string key)
        => GetStat(stat).RemoveModifier(key);

    public void ClearAllStatModifier()
    {
        foreach (StatSO stat in _stats)
        {
            //stat.ClearModifier();  //�����ð��� ������
        }
    }

}
