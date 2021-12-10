using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceController : MonoBehaviour
{
    [SerializeField]
    private int difficultyCurve = 1;
    [SerializeField]
    private int currentLevel = 1;
    [SerializeField]
    private int currentExp = 0;
    [SerializeField]
    private int expToLevel = 100;

    [SerializeField]
    private ExperienceBarUi expBarUi;

    private static ExperienceController instance;
    public static ExperienceController Instance { get => instance; }

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
        RefreshExpBar();
    }

    public void AddExp(int exp)
    {
        currentExp += exp;
        CheckForLvlUp();
        RefreshExpBar();
    }

    private void CheckForLvlUp()
    {
        if (currentExp >= expToLevel)
        {
            LevelUp();
            RefreshExpBar();
            CheckForLvlUp();
        }
    }

    public void LevelUp()
    {
        currentLevel += 1;

        currentExp -= expToLevel;
        expToLevel = (currentLevel + 1) * currentLevel * difficultyCurve;
    }

    private void RefreshExpBar()
    {
        expBarUi.Repaint(currentLevel, currentExp, expToLevel);
    }
}