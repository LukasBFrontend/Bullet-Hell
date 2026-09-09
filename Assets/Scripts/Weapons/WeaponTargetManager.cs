using UnityEngine;

public class WeaponTargetManager : MonoBehaviour
{
    public WeaponScriptableObject Weapon 
    { 
        get { return _weapon; } 
        set { _weapon = value; }
    }
    WeaponScriptableObject _weapon;

    void Update()
    {
        Debug.Log(Logic.PlayerAimDirection);
        transform.rotation = Quaternion.Euler(new (0, 0, Mathf.Rad2Deg * Mathf.Atan2(Logic.PlayerAimDirection.y, Logic.PlayerAimDirection.x )));
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
}
