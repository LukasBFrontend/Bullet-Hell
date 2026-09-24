using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class BeeController : MonoBehaviour
{
    [Range(0.5f, 50f)]
    [SerializeField] float moveSpeed;
    Enemy _enemy;
    Rigidbody2D _rigidbody;

    void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _rigidbody = _enemy.Rigidbody;
    }


    void Update()
    {
        Vector2 dir = GameUtils.PlayerToEnemyDir(GameStateManager.Instance.Player, _enemy);

        _rigidbody.linearVelocity = dir * moveSpeed;
    }
}
