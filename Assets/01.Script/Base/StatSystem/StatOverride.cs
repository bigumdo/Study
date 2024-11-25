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
        // 원본을 복사해 값을 주고
        StatSO newStat = _stat.Clone() as StatSO;

        //isUseOverride가 True라면 _overrideBaseValue값으로 BaseValue를 바꿔준다.
        if (_isUseOverride)
            newStat.BaseValue = _overrideBaseValue;
        //아니면 그냥 복사만한 StatSO를 준다
        return newStat;
    }
}
