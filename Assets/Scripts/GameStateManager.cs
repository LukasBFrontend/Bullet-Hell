using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    public Player Player => _player;
    Player _player;

    void OnEnable()
    {
        _player = FindAnyObjectByType<Player>();
    }
}
