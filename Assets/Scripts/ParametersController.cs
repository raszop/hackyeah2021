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

    public List<Parameter> Parameters { get => parameters; set => parameters = value; }

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
        this.parameters = PlayerData.Instance.ParametersData;
        OnParametersChanged?.Invoke();

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

    public void ApplyMultiplierChange(UpgradeEffect effect)
    {
        Parameter p = parameters.Find(x => x.ParameterId == effect.Parameter);        
        p.baseDetoriorationMultiplier -= effect.MultiplierChange;
    }

    public void ApplyParameterChange(Parameters parameter, float value)
    {
        Parameter p = parameters.Find(x => x.ParameterId == parameter);
        p.Value = Mathf.Clamp(p.Value - value, 0, p.MaxValue);
    }

    public string GetParameterName(Parameters parameterId)
    {
        return parameters.Find(x => x.ParameterId == parameterId).ParameterName;
    }
}

[System.Serializable]
public class Parameter
{
    public Parameters ParameterId;
    public string ParameterName;
    public float Value = 0;
    public float MaxValue = 10;
    public string Information = "info";
    [Header("detorioration")]
    public float baseDetoriorationValue = 1;
    public float baseDetoriorationMultiplier = 0.1F;
}

public enum Parameters
{
    AirPollution = 0,
    CarbonDioxide = 1,
    Temperature = 2,
    WaterLevel = 3,
    RubbishProduction = 4
}