using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class AgentRenderer : MonoBehaviour,IAgentComponent
{
    public float FacingDirection { get; private set; } = 1;

    private Agent _agent;
    private Animator _animator;
    public void Initialize(Agent entity)
    {
        _agent = entity;
        _animator = GetComponent<Animator>();
    }

    public void SetParam(AnimParamSO param, bool value) => _animator.SetBool(param.hashValue, value);
    public void SetParam(AnimParamSO param, float value) => _animator.SetFloat(param.hashValue, value);
    public void SetParam(AnimParamSO param, int value) => _animator.SetInteger(param.hashValue, value);
    public void SetParam(AnimParamSO param) => _animator.SetTrigger(param.hashValue);

    #region FlipControl

    public void Flip()
    {
        FacingDirection *= -1;
        _agent.transform.Rotate(0, 180f, 0);
    }

    public void FlipController(float xMove)
    {
        if (Mathf.Abs(FacingDirection + xMove) < 0.5f)
            Flip();
    }

    #endregion
}
