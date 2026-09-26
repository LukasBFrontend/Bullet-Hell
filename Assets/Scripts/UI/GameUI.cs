using UnityEngine;
using UnityEngine.UIElements;

public class GameUIHandler : MonoBehaviour {
    [SerializeField] PanelRenderer panelRenderer;
    ProgressBar _healthBar, _expBar;
    Player _player;

    void Awake()
    {
        VisualElement root = panelRenderer.visualTreeAsset.Instantiate();
        _player = GameStateManager.Instance.Player;
        _healthBar = root.Q<ProgressBar>("HealthBar");
        _expBar = root.Q<ProgressBar>("ExpBar");
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
