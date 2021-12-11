using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesUiController : MonoBehaviour
{
    [SerializeField]
    List<UpgradeSelectButton> availableUpgrades;
    [SerializeField]
    private Button buyUpgradeButton;
    [SerializeField]
    private TextMeshProUGUI selectedUpgradeDescripion;
    [SerializeField]
    private Button closeWindowButton;

    private Upgrade selectedUpgrade;

    public void DisplayUpgrades(List<string> upgrades)
    {
        for(int i=0;i<availableUpgrades.Count;i++)
        {
            availableUpgrades[i].SetSkill(upgrades[i]);
        }

        this.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        foreach(UpgradeSelectButton upgrade in availableUpgrades)
        {
            upgrade.OnUpgradeSelected += SelectUpgrade;
        }

        buyUpgradeButton.onClick.AddListener(TryBuyingUpgrade);
        closeWindowButton.onClick.AddListener(CloseWindow);
    }

    private void OnDisable()
    {
        foreach(UpgradeSelectButton upgrade in availableUpgrades)
        {
            upgrade.OnUpgradeSelected -= SelectUpgrade;
        }

        buyUpgradeButton.onClick.RemoveListener(TryBuyingUpgrade);
        closeWindowButton.onClick.RemoveListener(CloseWindow);
    }

    private void TryBuyingUpgrade()
    {
        if(MoneyController.Instance.Money >= selectedUpgrade.UpgradePrice)
        {
            MoneyController.Instance.Money -= selectedUpgrade.UpgradePrice;
            UnlockUpgrade(selectedUpgrade);
        }
    }

    private void SelectUpgrade(string upgradeId)
    {
        Upgrade upgrade = UpgradesController.Instance.GetUpgrade(upgradeId);

        selectedUpgradeDescripion.text = GenerateDescription(upgrade);
    }

    private void UnlockUpgrade(Upgrade upgrade)
    {
        ApplyUpgradeEffects(upgrade);
    }

    private void ApplyUpgradeEffects(Upgrade upgrade)
    {
        upgrade.UpgradeEffects.ForEach(x =>
        {
            ParametersController.Instance.ApplyMultiplierChange(x);
        });
    }

    private string GenerateDescription(Upgrade upgrade)
    {
        string s =
            upgrade.UpgradeDescription + " Cena: " +
            upgrade.UpgradePrice;

        return s;
    }

    private void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
