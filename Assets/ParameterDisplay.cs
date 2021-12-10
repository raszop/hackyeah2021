using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParameterDisplay : MonoBehaviour
{
    [SerializeField]
    private Parameters parameterId;
    [SerializeField]
    private TextMeshProUGUI parameterName;
    [SerializeField]
    private Image bar;
    [SerializeField]
    private Button infoButton;

    Parameter thisParameter;

    private void Start()
    {
        InitParameter();
    }

    private void OnEnable()
    {
        infoButton.onClick.AddListener(DisplayInfo);
    }

    private void OnDisable()
    {
        infoButton.onClick.RemoveListener(DisplayInfo);
    }

    private void DisplayInfo()
    {
        InfoWindow.Instance.ShowInfo(thisParameter.Information);
    }

    private void InitParameter()
    {
        thisParameter = ParametersController.Instance.GetParameter(parameterId);

        Repaint();
    }

    private void Repaint()
    {
        parameterName.text = thisParameter.ParameterName;
        bar.fillAmount = thisParameter.Value / thisParameter.MaxValue;
    }
}
