using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI counter;

    public void Refresh(int count)
    {
        counter.text = count.ToString();
    }
}
