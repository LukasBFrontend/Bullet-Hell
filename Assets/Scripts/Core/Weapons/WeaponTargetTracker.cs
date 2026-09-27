using UnityEngine;

public class WeaponTargetTracker : MonoBehaviour
{
    [Tooltip("Enemies inside the collider are considered within range of the tracker.")]
    [SerializeField] Collider2D collider;
    SO_WeaponData _weapon;

    public void Initialize(SO_WeaponData weapon)
    {
        _weapon = weapon;
    }

    private void Update()
    {
        Vector2 closestDir = GameUtils.ClosestEnemyToPlayerDir(GameStateManager.Instance.Player);
        transform.rotation = Quaternion.Euler(new (0, 0, Mathf.Rad2Deg * Mathf.Atan2(closestDir.y, closestDir.x )));
    }

    private void Awake()
    {
        if (collider == null)
        {
            Debug.LogWarning($"WeaponTargetTracker assigned to {name} is missing a Collider2D reference and will not function as intended.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Enemy>(out var enemy))
        {
            return;
        }

        _weapon.EnterIntoRange(enemy);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent<Enemy>(out var enemy))
        {
            return;
        }

        _weapon.ExitFromRange(enemy);
    }
}
