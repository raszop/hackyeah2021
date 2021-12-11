using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    private int money;

    private static MoneyController instance;
    public static MoneyController Instance { get => instance; }

    public int Money { get => money; set => money = value; }

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
}
