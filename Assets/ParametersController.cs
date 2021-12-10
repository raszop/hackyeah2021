using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParametersController : MonoBehaviour
{
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

    public Parameter GetParameter(Parameters parameterId)
    {
        return parameters.Find(x => x.ParameterId == parameterId);
    }

}

[System.Serializable]
public class Parameter
{
    public Parameters ParameterId;
    public string ParameterName;
    public float Value;
    public float MaxValue;
}

public enum Parameters
{
    AirPollution = 0,
    CarbonDioxide = 1,
    Temperature = 2,
    WaterLevel = 3,
    RubbishProduction = 4
}