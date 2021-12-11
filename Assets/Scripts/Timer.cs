using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float hourTime = 3F;

    public Action OnHourPassed;

    private static Timer instance;
    public static Timer Instance { get => instance; }

    public int CurrentHour { get => PlayerData.Instance.CurrentHour; }
    public int CurrentDay { get => PlayerData.Instance.CurrentDay; }

    private float lastHourPassed;

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
        //PassHour();
    }

    private void UpdateTime()
    {
        PlayerData.Instance.CurrentHour += 1;
        PlayerData.Instance.CurrentDay = PlayerData.Instance.CurrentHour > 23 ? PlayerData.Instance.CurrentDay += 1 : PlayerData.Instance.CurrentDay;
        PlayerData.Instance.CurrentHour = PlayerData.Instance.CurrentHour > 23 ? 0 : PlayerData.Instance.CurrentHour;
    }

    private void Update()
    {
        if(Time.time > lastHourPassed)
        {
            PassHour();
        }
    }

    private void PassHour()
    {
        lastHourPassed = Time.time + hourTime;
        UpdateTime();
        OnHourPassed?.Invoke();
    }
}
