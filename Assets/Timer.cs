using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int startingDay;
    [SerializeField]
    private int startingHour;

    [SerializeField]
    private int currentHour;
    [SerializeField]
    private int currentDay;

    [SerializeField]
    private float hourTime = 3F;

    public Action OnHourPassed;

    private static Timer instance;
    public static Timer Instance { get => instance; }

    public int CurrentHour { get => currentHour; }
    public int CurrentDay { get => currentDay; }

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
        currentHour = startingHour;
        currentDay = startingDay;
    }

    private void UpdateTime()
    {
        currentHour += 1;
        currentDay = currentHour > 23 ? currentDay += 1 : currentDay;
        currentHour = currentHour > 23 ? 0 : currentHour;
    }

    private void Update()
    {
        if(Time.time > lastHourPassed)
        {
            lastHourPassed = Time.time + hourTime;
            UpdateTime();
            OnHourPassed?.Invoke();
        }
    }
}
