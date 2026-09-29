using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof (BaseCharacter))]
public class Health : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] int health;
    public int Current => health;
    public int Max => _maxHealth;
    int _maxHealth;
    BaseCharacter _character;

    void Awake()
    {
        _maxHealth = health;
        _character = GetComponent<BaseCharacter>();
    }

    /// <summary>
    /// Subtracts amount from the character health. If it reaches zero, invokes Die().
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, _maxHealth);

        if (_character is Player)
        {
            GameEvents.RaiseHealthChanged(health, _maxHealth);
        }

        if (health <= 0)
        {
            _character.Die();
        }

    }

    /// <summary>
    /// Adds amount to character health up to MaxHealth
    /// </summary>
    /// <param name="amount"></param>
    void Heal(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning($"Tried invoking method <b><color=white>{nameof(Heal)}()</color></b> of <b>{name}</b> with a non-positive value.");
            return;
        }

        health = Mathf.Clamp(health + amount, 0, _maxHealth);
    }

    /// <summary>
    /// Sets the
    /// </summary>
    /// <param name="maxHealth"></param>
    public void SetMaxHealth(int maxHealth)
    {
        if (maxHealth <= _maxHealth)
        {
            Debug.LogWarning($"Tried invoking method <b><color=white>{nameof(Heal)}()</color></b> of <b>{name}</b> with value = {maxHealth} which is lower than current MaxHealth = {_maxHealth}.");
            return;
        }

        int difference = maxHealth - _maxHealth;
        _maxHealth = maxHealth;

        Heal(difference);
    }
}
