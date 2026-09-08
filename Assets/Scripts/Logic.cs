using UnityEngine;

public class Logic : MonoBehaviour
{
    public static Player Player
    {
        get
        {
            return _player;
        }
        private set
        {
            _player = value;
        }
    }

    static Player _player;
    void Awake()
    {
        _player = FindAnyObjectByType<Player>();
    }
}
