using UnityEngine.Events;

public static class GameEvents
{
    public static UnityEvent<int, int> HealthChanged = new();
    public static UnityEvent<int, int> ExpChanged = new();
    public static UnityEvent<int, int> LvlUpEvent = new();
    public static UnityEvent GameOver = new();

    public static void RaiseHealthChanged(int currentHealth, int maxHealth)
    {
        HealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public static void RaiseExpChanged(int exp, int requiredExp)
    {
        ExpChanged?.Invoke(exp, requiredExp);
    }

    public static void RaiseLvlUpEvent(int oldLvl, int newLvl)
    {
        LvlUpEvent?.Invoke(oldLvl, newLvl);
    }
    public static void RaiseGameOver()
    {
        GameOver?.Invoke();
    }
}
