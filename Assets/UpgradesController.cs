using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesController : MonoBehaviour
{
    [SerializeField]
    private List<Upgrade> upgrades;

    private static UpgradesController instance;
    public static UpgradesController Instance { get => instance; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(this.gameObject);
        }
    }

    public Upgrade GetUpgrade(string upgradeId)
    {
        return upgrades.Find(x => x.UpgradeName == upgradeId);
    }
}

[System.Serializable]
public class Upgrade
{
    public string UpgradeName;
    public Sprite UpgradeIcon;
    public string UpgradeDescription;
    public int UpgradePrice;
    public List<UpgradeEffect> UpgradeEffects;
}

[System.Serializable]
public class UpgradeEffect
{
    public Parameters Parameter;
    public float MultiplierChange;
}