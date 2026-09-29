using UnityEngine;

[RequireComponent(typeof(Player))]
public class Movement : MonoBehaviour
{
    [SerializeField] float baseMoveSpeed = 10;
    Player _player;
    public void SetInput(Vector2 moveInput)
    {

        _player.Rigidbody.linearVelocity = moveInput * baseMoveSpeed;
    }

    void Awake()
    {
        _player = GetComponent<Player>();
    }
}
