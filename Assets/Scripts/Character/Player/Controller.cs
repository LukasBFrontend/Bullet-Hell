using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// The player controller component.
/// </summary>
[RequireComponent(typeof(Player))]
public class Controller : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] InputActionReference move;
    [Header("Config")]
    [Range(0.5f, 20f)]
    [SerializeField] float baseMoveSpeed = 1;
    Rigidbody2D _rigidbody;
    bool _isAttackReady = true;
    Player _player;

    void OnEnable()
    {
        _player = GetComponent<Player>();
        _rigidbody = _player.Rigidbody;

        move.action.Enable();
    }

    void OnDisable()
    {
        move.action.Disable();
    }

    void Update()
    {
        SetMoveInput(move.action.ReadValue<Vector2>());
    }

    void OnAttackActionPerformed(InputAction.CallbackContext context)
    {
        bool attackValue = context.action.IsPressed();

        if (attackValue && _isAttackReady)
        {
            _isAttackReady = false;
        }
        else if (!attackValue)
        {
            _isAttackReady = true;
        }
    }

    void SetMoveInput(Vector2 moveInput)
    {
        _rigidbody.linearVelocity = moveInput * baseMoveSpeed;
    }
}
