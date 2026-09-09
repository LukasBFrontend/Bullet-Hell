using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct AttackScaling
{
    [SerializeField]
    int damageIncrease;
    [Range(.5f, .975f)]
    [SerializeField]
    float cooldownDecreaseFactor;
}
public enum TargetingMode
{
    SpreadEven,
    PredictLocation,
    Boomerang,
}

[System.Serializable]
struct AreaWeaponConfig
{        
    [Tooltip("The prefab needs to have a Weapon Target Manager component")]
    public GameObject AreaPrefab;
}
[System.Serializable]
struct ProjectileWeaponConfig
{
    [Tooltip("The prefab needs to have a Weapon Target Manager component")]
    public GameObject ProjectilePrefab;
    public TargetingMode targetingMode;
}

[System.Serializable]
struct AttackConfig
{
    [Range(1, 100)]
    [SerializeField] int baseDamage;
    [Range(.1f, 5f)]
    [SerializeField] float baseCooldown;
    [Range(1, 10)]
    [SerializeField] int baseProjectileCount;
    [Range(.1f, 2f)]
    [SerializeField] float duration;
    [SerializeField] AttackScaling scalingConfig;
    public float Cooldown { get { return baseCooldown; } }
    public int Damage { get { return baseDamage; } }
    public float Duration { get { return duration; } }
    public int ProjectileCount { get { return baseProjectileCount; } }

}
public enum WeaponType
{
    Area,
    Projectile
}

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/WeaponData")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] WeaponType weaponType;
    [SerializeField] Sprite sprite;
    [SerializeField] LayerMask hitMask;
    [SerializeField] AttackConfig attackConfig;
    [SerializeField] ProjectileWeaponConfig projectileWeaponDependencies;
    [SerializeField] AreaWeaponConfig areaWeaponDependencies;
    float _lastAttackTime;
    MonoBehaviour _activeMonoBehavior;
    GameObject _weaponModel;
    List<Enemy> _targetsInRange;
    WeaponTargetManager _weaponTargetManager;
    IEnumerator AttackRoutine(float duration, int projectileCount)
    {
        float elapsed = 0f;
        float timestep = duration / projectileCount;

        while (elapsed <= duration)
        {
            _targetsInRange.RemoveAll(enemy => enemy == null);
            List<Enemy> currentTargets = new (_targetsInRange);

            if (weaponType == WeaponType.Area)
            {
                Punch(currentTargets);
            }
            else if (weaponType == WeaponType.Projectile)
            {
                Shoot(currentTargets);
            }

            yield return new WaitForSeconds(timestep);
            elapsed += timestep;
        }
    }
    public void Attack()
    {
        if (Time.time <= attackConfig.Cooldown + _lastAttackTime)
        {
            return;
        }

        _lastAttackTime = Time.time;
        _activeMonoBehavior.StartCoroutine(AttackRoutine(attackConfig.Duration, attackConfig.ProjectileCount));
    }

    public void EnterRange(Enemy enemy)
    {
        _targetsInRange.Add(enemy);
    }
    public void ExitRange(Enemy enemy)
    {
        _targetsInRange.Remove(enemy);
    }

    void Shoot(List<Enemy> enemies)
    {
        Debug.Log("Bang!");
    }

    void Punch(List<Enemy> enemies)
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.TakeDamage(attackConfig.Damage);
            Debug.Log("Whack!");
        }
    }

    public void Unlock(Transform parent, MonoBehaviour activeMonoBehavior)
    {
        this._activeMonoBehavior = activeMonoBehavior;
        _lastAttackTime = 0;

        if (weaponType == WeaponType.Area)
        {
            _weaponModel = Instantiate(areaWeaponDependencies.AreaPrefab);
            _weaponModel.transform.SetParent(parent);
            _weaponModel.transform.localPosition = Vector2.zero;
            _weaponModel.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
        else if (weaponType == WeaponType.Projectile)
        {
            _weaponModel = Instantiate(projectileWeaponDependencies.ProjectilePrefab);
            _weaponModel.transform.SetParent(parent);
            _weaponModel.transform.localPosition = Vector2.zero;
            _weaponModel.transform.localRotation = Quaternion.Euler(Vector3.zero);
        
        }
        _weaponTargetManager = _weaponModel.GetComponent<WeaponTargetManager>();
        _weaponTargetManager.Weapon = this;
    }
}
