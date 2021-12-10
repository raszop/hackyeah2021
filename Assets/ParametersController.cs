using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParametersController : MonoBehaviour
{
    public Action OnParametersChanged;

    [SerializeField]
    private List<Parameter> parameters;

    private static ParametersController instance;
    public static ParametersController Instance { get => instance; }

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
        Timer.Instance.OnHourPassed += DetoriorateOverTime;
    }

    private void OnDestroy()
    {
        Timer.Instance.OnHourPassed -= DetoriorateOverTime;
    }

    public Parameter GetParameter(Parameters parameterId)
    {
        return parameters.Find(x => x.ParameterId == parameterId);
    }

    private void DetoriorateOverTime()
    {
        parameters.ForEach(x => Detoriorate(x));
        OnParametersChanged?.Invoke();
    }

    private void Detoriorate(Parameter p)
    {
        p.Value = Mathf.Clamp(p.Value + p.baseDetoriorationValue * p.baseDetoriorationMultiplier, p.Value, p.MaxValue);
    }
}

[System.Serializable]
public class Parameter
{
    public Parameters ParameterId;
    public string ParameterName;
    public float Value;
    public float MaxValue;
    public string Information;
    [Header("detorioration")]
    public float baseDetoriorationValue;
    public float baseDetoriorationMultiplier;
}

public enum Parameters
{
    AirPollution = 0,
    CarbonDioxide = 1,
    Temperature = 2,
    WaterLevel = 3,
    RubbishProduction = 4
}