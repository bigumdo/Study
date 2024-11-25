using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public bool IsDead { get; set; }

    //플레이어 컴포넌트를 한번에 관리하기 위해 만든 Dictionary
    protected Dictionary<Type, IAgentComponent> _components;

    protected virtual void Awake()
    {
        _components = new Dictionary<Type, IAgentComponent>();
        //자식들을 전부 돌면서 IAgentComoponent를 가지고 있는 체크해서 Dictionary에 추가한다.
        GetComponentsInChildren<IAgentComponent>(true).ToList()
            .ForEach(component => _components.Add(component.GetType(), component));

        InitComponents();
        AfterInitComponents();
    }

    private void InitComponents()
    {
        //IAgentComponent으로 구현된 Initialize를 전부 실행
        _components.Values.ToList().ForEach(component => component.Initialize(this));
    }

    protected virtual void AfterInitComponents()
    {
        //_components에 있는 객체에 IAfterInitable이 있다면 그 객체들에  AfterInit실행
        _components.Values.ToList().ForEach(component =>
        {
            if (component is IAfterInitable afterInitable)
            {
                afterInitable.AfterInit();
            }
        });
    }

    public T GetCompo<T>(bool isDerived = false) where T : IAgentComponent
    {
        if (_components.TryGetValue(typeof(T), out IAgentComponent component))
        {
            return (T)component;
        }

        if (isDerived == false)
            return default;

        Type findType = _components.Keys.FirstOrDefault(t => t.IsSubclassOf(typeof(T)));
        if (findType != null)
            return (T)_components[findType];

        return default;
    }
}
