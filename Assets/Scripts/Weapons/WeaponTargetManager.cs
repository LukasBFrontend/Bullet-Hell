using UnityEngine;

public class WeaponTargetManager : MonoBehaviour
{
    [SerializeField] WeaponData _weapon;
    public WeaponData Weapon => _weapon;

    void Update()
    {
        transform.rotation = Quaternion.Euler(new (0, 0, Mathf.Rad2Deg * Mathf.Atan2(GameUtils.ClosestEnemyDir().y, GameUtils.ClosestEnemyDir().x )));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Enemy>(out var enemy))
        {
            return;
        }

        _weapon.EnterRange(enemy);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent<Enemy>(out var enemy))
        {
            return;
        }

        _weapon.ExitRange(enemy);
    }

    public void Initialize(WeaponData weapon)
    {
        _weapon = weapon;
    }
}
