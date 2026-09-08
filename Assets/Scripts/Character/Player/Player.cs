using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : Character
{
    [HideInInspector] public UnityEvent<int, int, int> OnExpChanged;
    public int Lvl { get { return _lvl; } set { _lvl = value; } }
    public int Exp { get { return _exp;} }
    int _lvl = 1;
    int _exp = 0;

    void LvlUp()
    {
        _lvl++;
    }

    public int ExpToLvlUp()
    {
        return 100 + _lvl * 10;
    }

    public void GainExp(int amount)
    {
        _exp += amount;

        int requiredExp = ExpToLvlUp();

        if (_exp < requiredExp)
        {
            OnExpChanged.Invoke(_exp, requiredExp, _lvl);
            return;
        }
        int leftover = _exp - requiredExp;

        LvlUp();
        _exp = leftover;
        OnExpChanged.Invoke(_exp, requiredExp, _lvl);
    }

    void Start()
    {
        MaxHealth = Health;
        OnDeath = () =>
        {
            SceneManager.LoadScene("Main");
        };
    }

    void Update()
    {
        
    }
}
