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
    [SerializeField]
    private BarColorizer barColorizer;

    Parameter thisParameter;

    private void Start()
    {
        ParametersController.Instance.OnParametersChanged += Repaint;
    }

    private void OnDestroy()
    {
        ParametersController.Instance.OnParametersChanged -= Repaint;
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
        InfoWindow.Instance.ShowInfo(thisParameter.Information, thisParameter.ParameterName);
    }

    private void Repaint()
    {
        if(thisParameter == null)
        {
            thisParameter = ParametersController.Instance.GetParameter(parameterId);
        }

        parameterName.text = thisParameter.ParameterName;
        bar.fillAmount = thisParameter.Value / thisParameter.MaxValue;
        barColorizer.AdjustLevel(bar.fillAmount);
    }
}
