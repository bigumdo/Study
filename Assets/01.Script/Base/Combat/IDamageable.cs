using UnityEngine;

public interface IDamageable
{
    public void ApplyDamage(float damage, Vector2 direction, Vector2 knockBackPower, Agent dealer);
}
