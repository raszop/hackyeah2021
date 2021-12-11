using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    private MoneyCounter moneyCounterUi;

    private static MoneyController instance;
    public static MoneyController Instance { get => instance; }

    public int Money { 
        get => PlayerData.Instance.Money;
        set
        {
            PlayerData.Instance.Money = value;
            moneyCounterUi.Refresh(value);
        }
    }

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
        moneyCounterUi.Refresh(PlayerData.Instance.Money);
    }
}
