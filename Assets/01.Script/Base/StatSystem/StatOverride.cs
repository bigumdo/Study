using System;
using UnityEngine;

[Serializable]
public class StatOverride
{
    [SerializeField] private StatSO _stat;
    [SerializeField] private bool _isUseOverride;
    [SerializeField] private float _overrideBaseValue;

    public StatOverride(StatSO stat) => _stat = stat;

    public StatSO CreateStat()
    {
        // ������ ������ ���� �ְ�
        StatSO newStat = _stat.Clone() as StatSO;

        //isUseOverride�� True��� _overrideBaseValue������ BaseValue�� �ٲ��ش�.
        if (_isUseOverride)
            newStat.BaseValue = _overrideBaseValue;
        //�ƴϸ� �׳� ���縸�� StatSO�� �ش�
        return newStat;
    }
}
