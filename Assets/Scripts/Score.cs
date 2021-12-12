using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class Score : MonoBehaviour
{
    int plus;
    int minus;
    [SerializeField] [Range(3, 7)] public int maxMinus;
    [SerializeField] private GameObject minusDisplay;
    [SerializeField] private GameObject plusDisplay;
    [SerializeField] private GameObject EndGameBanner;

    private void Start()
    {
        SetMinusDisplay();
        SetPlusDisplay();
        EndGameBanner.SetActive(false);
    }

    private void SetPlusDisplay()
    {
        plusDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = plus.ToString();
    }

    private void CheckMaxMinus()
    {
        if (minus >= maxMinus)
            EndGame();
    }

    public float GetOverallScore()
    {
        var overallScore = plus - minus * 2;
        if (overallScore < 0)
            overallScore = 0;
        return overallScore;
    }

    public void Minus()
    {
        minus++;
        SetMinusDisplay();
        CheckMaxMinus();
    }

    public void Minus(int value)
    {
        minus += value;
        SetMinusDisplay();
        CheckMaxMinus();
    }

    private void SetMinusDisplay()
    {
        var minusDisplayText = $"{minus.ToString()}/{maxMinus}";
        minusDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = minusDisplayText;
    }

    public void Plus()
    {
        plus++;
        SetPlusDisplay();
    }

    public void EndGame()
    {
        EndGameBanner.SetActive(true);
        Debug.Log($"Game End, overall score: {GetOverallScore()}");
        Time.timeScale = 0.0f;
        GlobalDataTransmitter.Instance.EndAndExitMinigame((int)GetOverallScore());
        //throw new System.NotImplementedException();
    }
}