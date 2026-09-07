using UnityEngine;
using UnityEngine.UIElements;

public class GameUIHandler : MonoBehaviour {
    [SerializeField] Player Player;
    [SerializeField] UIDocument UIDoc;
    private ProgressBar _healthBar;

    private void Start() {
        _healthBar = UIDoc.rootVisualElement.Q<ProgressBar>("HealthBar");
        Player.OnHealthChanged.AddListener(UpdateHealthBar);
        UpdateHealthBar(Player.Health, Player.MaxHealth);

        _healthBar.highValue = Player.MaxHealth;
    }

    void UpdateHealthBar(int current, int max) {
        _healthBar.title = $"{current}/{max}";
        _healthBar.value = current;
    }
}
