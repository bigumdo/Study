using System;
using UnityEngine;

public class AgentAnimationTrigger : MonoBehaviour,IAgentComponent
{
    
    public event Action OnAnimationEndTriggerEvent;
    public event Action OnAttackTriggerEvent;

    protected Agent _agent;

    public void Initialize(Agent agent)
    {
        _agent = agent;
    }

    protected virtual void AnimationEnd() => OnAnimationEndTriggerEvent?.Invoke();
    protected virtual void AttackTrigger() => OnAttackTriggerEvent?.Invoke();
}
