using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public bool IsDead { get; set; }

    //�÷��̾� ������Ʈ�� �ѹ��� �����ϱ� ���� ���� Dictionary
    protected Dictionary<Type, IAgentComponent> _components;

    protected virtual void Awake()
    {
        _components = new Dictionary<Type, IAgentComponent>();
        //�ڽĵ��� ���� ���鼭 IAgentComoponent�� ������ �ִ� üũ�ؼ� Dictionary�� �߰��Ѵ�.
        GetComponentsInChildren<IAgentComponent>(true).ToList()
            .ForEach(component => _components.Add(component.GetType(), component));

        InitComponents();
        AfterInitComponents();
    }

    private void InitComponents()
    {
        //IAgentComponent���� ������ Initialize�� ���� ����
        _components.Values.ToList().ForEach(component => component.Initialize(this));
    }

    protected virtual void AfterInitComponents()
    {
        //_components�� �ִ� ��ü�� IAfterInitable�� �ִٸ� �� ��ü�鿡  AfterInit����
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
