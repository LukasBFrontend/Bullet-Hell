using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    [Tooltip("How much damage does the enemy deal on player collision?")]
    [Range(1, 100)]
    [SerializeField] int contactDamage;
    bool _canAttack = true;
    void Awake()
    {
        MaxHealth = Health;
        OnDeath = () =>
        {
            Destroy(gameObject);
        };
    }

    IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(.5f);
        _canAttack = true;
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (!other.collider.TryGetComponent<Player>(out var player) || !_canAttack)
        {
            return;
        }

        player.TakeDamage(contactDamage);

        StartCoroutine(AttackCooldown());
    }
}
