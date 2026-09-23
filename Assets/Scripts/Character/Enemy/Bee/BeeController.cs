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
        Vector2 _position = _rigidbody.position;
        Vector2 _targetPosition = GameUtils.Player.Rigidbody.position;
        Vector2 _dir = (_targetPosition - _position).normalized;

        _rigidbody.linearVelocity = _dir * moveSpeed;
    }
}
