using UnityEngine;
using UnityEngine.UIElements;

public class GameUIHandler : MonoBehaviour {
    [SerializeField] UIDocument UIDoc;
    ProgressBar _healthBar, _expBar;
    Player _player;

    void Awake()
    {
        _player = GameStateManager.Instance.Player;
        _healthBar = UIDoc.rootVisualElement.Q<ProgressBar>("HealthBar");
        _expBar = UIDoc.rootVisualElement.Q<ProgressBar>("ExpBar");
    }

    void Start() {
        UpdateExpBar(_player.Exp, _player.ExpToLvlUp(), _player.Lvl);
        UpdateHealthBar(_player.Health.Current, _player.Health.Max);
    }

    void OnEnable()
    {
        GameEvents.HealthChanged?.AddListener(UpdateHealthBar);
        GameEvents.ExpChanged?.AddListener(UpdateExpBar);
    }

    void OnDisable()
    {
        GameEvents.HealthChanged?.RemoveListener(UpdateHealthBar);
        GameEvents.ExpChanged?.RemoveListener(UpdateExpBar);
    }

    void UpdateHealthBar(int current, int max) {
        _healthBar.highValue = max;
        _healthBar.value = current;
        _healthBar.title = $"{current}/{max}";
    }

    void UpdateExpBar(int currentExp, int maxExp, int lvl )
    {
        _expBar.value = currentExp;
        _expBar.highValue = maxExp;
        _expBar.title = $"Lvl: {lvl}";
    }
}
