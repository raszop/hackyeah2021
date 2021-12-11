using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesWindowOpenButton : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private List<string> upgradesToBuy;

    private void OnEnable()
    {
        button.onClick.AddListener(DisplayUpgrades);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(DisplayUpgrades);
    }

    private void DisplayUpgrades()
    {
        UpgradesController.Instance.DisplayUpgrades(upgradesToBuy);
    }
}
