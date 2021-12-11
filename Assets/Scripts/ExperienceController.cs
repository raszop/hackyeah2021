using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceController : MonoBehaviour
{
    [SerializeField]
    private int difficultyCurve = 1;

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
        PlayerData.Instance.Experience += exp;
        CheckForLvlUp();
        RefreshExpBar();
    }

    private void CheckForLvlUp()
    {
        if (PlayerData.Instance.Experience >= PlayerData.Instance.ExpToLevel)
        {
            LevelUp();
            RefreshExpBar();
            CheckForLvlUp();
        }
    }

    public void LevelUp()
    {
        PlayerData.Instance.Level += 1;

        PlayerData.Instance.Experience -= PlayerData.Instance.ExpToLevel;
        PlayerData.Instance.ExpToLevel = (PlayerData.Instance.Level + 1) * PlayerData.Instance.Level * difficultyCurve;
    }

    private void RefreshExpBar()
    {
        expBarUi.Repaint(PlayerData.Instance.Level, PlayerData.Instance.Experience, PlayerData.Instance.ExpToLevel);
    }
}