using UnityEngine.Events;

public static class GameEvents
{
    public static UnityEvent<int, int> HealthChanged = new();
    public static UnityEvent<int, int, int> ExpChanged = new();
    public static UnityEvent GameOver = new();
    public static void RaiseHealthChanged(int currentHealth, int maxHealth)
    {
        HealthChanged?.Invoke(currentHealth, maxHealth);
    }
    public static void RaiseExpChanged(int exp, int requiredExp, int lvl)
    {
        ExpChanged?.Invoke(exp, requiredExp, lvl);
    }
    public static void RaiseGameOver()
    {
        GameOver?.Invoke();
    }
}
