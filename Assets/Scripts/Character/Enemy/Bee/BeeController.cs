using UnityEngine;

public class BeeController : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [Range(0.5f, 50f)]
    [SerializeField] float moveSpeed;
    Rigidbody2D _rigidbody;
    void Awake()
    {
        _rigidbody = enemy.Rigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 _position = _rigidbody.position;
        Vector2 _targetPosition = Logic.Player.Rigidbody.position;
        Vector2 _dir = (_targetPosition - _position).normalized;

        _rigidbody.linearVelocity = _dir * moveSpeed;
    }
}
