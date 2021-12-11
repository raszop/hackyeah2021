using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUiController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentHour;
    [SerializeField]
    private TextMeshProUGUI currentDay;

    private void Start()
    {
        Timer.Instance.OnHourPassed += Repaint;
    }

    private void OnDestroy()
    {
        Timer.Instance.OnHourPassed -= Repaint;
    }

    private void Repaint()
    {
        currentHour.text = Timer.Instance.CurrentHour.ToString("D2");
        currentDay.text = Timer.Instance.CurrentDay.ToString();
    }

}
