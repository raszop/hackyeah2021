using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentChanger : MonoBehaviour
{
    [SerializeField]
    private List<EnvironmentElement> elements;

    private static EnvironmentChanger instance;
    public static EnvironmentChanger Instance { get => instance; }

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

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        elements.ForEach(x => TryAdjustingState(x));
    }

    private void TryAdjustingState(EnvironmentElement element)
    {
        bool enabled = element.InitialState;
        if(PlayerData.Instance.UnlockedUpgrades.Contains(element.UpgradeToChangeState))
        {
            enabled = element.StateWithUpgrade;
        }

        element.GameObject.SetActive(enabled);
    }
}

[System.Serializable]
public class EnvironmentElement
{
    public GameObject GameObject;
    public bool InitialState;
    public string UpgradeToChangeState;
    public bool StateWithUpgrade;
}