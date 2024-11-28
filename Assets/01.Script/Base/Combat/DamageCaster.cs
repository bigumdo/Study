using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageCaster : MonoBehaviour
{
    [SerializeField] protected int _maxHitCount;
    [SerializeField] protected ContactFilter2D _contactFilter;
    protected Collider2D[] _hitResults;

    protected Agent _owner;

    public virtual void InitCaster(Agent owner)
    {
        _hitResults = new Collider2D[_maxHitCount];
        _owner = owner;
    }

    public abstract bool CastDamage(float damage, Vector2 knockBack);
}
