using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The main player component.
/// </summary>
[RequireComponent(typeof(Stats))]
public class Player : Character
{
    [SerializeField] Stats stats;
    public Stats Stats => stats;
    public int Lvl => _lvl;
    public int Exp => _exp;
    int _lvl = 1;
    int _exp = 0;

    /// <summary>
    /// Calculates total exp required to lvl up from the current lvl to the next.
    /// </summary>
    /// <returns>The exp</returns>
    public int ExpToLvlUp()
    {
        return 100 + _lvl * 10;
    }

    /// <summary>
    /// Adds exp to the player exp and invokes LvlUp() if the updated exp is sufficient.
    /// </summary>
    /// <param name="amount"></param>
    public void GainExp(int amount)
    {
        _exp += amount;

        int requiredExp = ExpToLvlUp();

        if (_exp < requiredExp)
        {
            GameEvents.RaiseExpChanged(_exp, requiredExp, _lvl);
            return;
        }
        int leftover = _exp - requiredExp;

        LvlUp();
        _exp = leftover;
        GameEvents.RaiseExpChanged(_exp, requiredExp, _lvl);
    }

    public override void Die()
    {
        SceneManager.LoadScene("Main");
    }

    private void LvlUp()
    {
        _lvl++;
    }
}
