using UnityEngine;

public class Enemy : Character
{
    void Awake()
    {
        MaxHealth = Health;
        OnDeath = () =>
        {
            Destroy(gameObject);
        };
    }
}
