using UnityEngine;
using UnityEngine.UIElements;

public class UIUpgradeHandler : MonoBehaviour {
    [SerializeField] PanelRenderer panelRenderer;
    Button _upgradeButtonOne, _upgradeButtonTwo, _upgradeButtonThree;

    void OnEnable()
    {
        panelRenderer.RegisterUIReloadCallback(OnUIReload);
        _upgradeButtonOne.clicked += OnUpgradeButtonOneClick;
        _upgradeButtonTwo.clicked += OnUpgradeButtonTwoClick;
        _upgradeButtonThree.clicked += OnUpgradeButtonThreeClick;
    }

    void OnDisable()
    {
        panelRenderer.UnregisterUIReloadCallback(OnUIReload);
    }

    void OnUIReload(PanelRenderer renderer, VisualElement rootElement)
    {
        // Get buttons
        _upgradeButtonOne = rootElement.Q<Button>("UpgradeButton1");
        _upgradeButtonTwo = rootElement.Q<Button>("UpgradeButton2");
        _upgradeButtonThree = rootElement.Q<Button>("UpgradeButton3");
        
    }

    void OnUpgradeButtonOneClick()
    {
        UpgradeOptionManager.Instance.SelectOptionOne();
    }

    void OnUpgradeButtonTwoClick()
    {
        UpgradeOptionManager.Instance.SelectOptionTwo();
    }

    void OnUpgradeButtonThreeClick()
    {
        UpgradeOptionManager.Instance.SelectOptionThree();
    }
}
