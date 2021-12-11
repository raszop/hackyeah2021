using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class Score : MonoBehaviour
{
    int plus;
    int minus;
    [SerializeField] [Range(1, 5)] public int maxMinus;


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
        CheckMaxMinus();
    }

    public void Minus(int value)
    {
        minus -= value;
        CheckMaxMinus();
    }

    public void Plus()
    {
        plus++;
    }

    public void EndGame()
    {
        Debug.Log($"Game End, overall score: {GetOverallScore()}");
        Time.timeScale = 0.0f;
        throw new System.NotImplementedException();
    }
}