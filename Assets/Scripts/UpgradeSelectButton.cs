using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UpgradeSelectButton : MonoBehaviour
{
    public Action<string> OnUpgradeSelected;

    [SerializeField]
    private Button button;
    [SerializeField]
    private Image upgradeIcon;
    [SerializeField]
    private TextMeshProUGUI upgradeName;

    private string thisUpgrade;

    private void OnEnable()
    {
        button.onClick.AddListener(SelectSkill);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(SelectSkill);
    }

    public void SetSkill(string skillName)
    {
        Upgrade upgrade = UpgradesController.Instance.GetUpgrade(skillName);

        this.thisUpgrade = skillName;
        this.upgradeName.text = skillName;
        //this.upgradeIcon.sprite = upgrade.UpgradeIcon;

    }

    private void SelectSkill()
    {
        OnUpgradeSelected?.Invoke(thisUpgrade);
    }
}
