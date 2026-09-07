using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Player player;
    [Range(0.5f, 20f)]
    [SerializeField] float speed = 1;
    InputAction moveAction;
    InputAction attackAction;
    Rigidbody2D _rigidbody;
    bool _isAttackReady = true;
    
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
        _rigidbody = player.Rigidbody;
    }

    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        bool attackValue = attackAction.IsPressed();

        _rigidbody.linearVelocity = moveValue * speed;

        if (attackValue && _isAttackReady)
        {
            _isAttackReady = false;
        }else if (!attackValue)
        {
            _isAttackReady = true;
        }
    }
}
