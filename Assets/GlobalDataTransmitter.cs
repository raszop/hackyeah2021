using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GlobalDataTransmitter : MonoBehaviour
{
    [SerializeField]
    private List<Parameter> initialParametersData;
    [SerializeField]
    private bool alwaysInitPlayerDataOnStart;

    private Minigames currentMinigame;
    private int currentMinigameScore;
    private bool isPlayingMinigame;

    public Minigames CurrentMinigame { get => currentMinigame; set => currentMinigame = value; }
    public int CurrentMinigameScore { get => currentMinigameScore; set => currentMinigameScore = value; }
    public bool IsPlayingMinigame { get => isPlayingMinigame; set => isPlayingMinigame = value; }

    private static GlobalDataTransmitter instance;
    public static GlobalDataTransmitter Instance { get => instance; }

    private float menuLoadDelay = 3.0F;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            HandlePlayerDataInit();
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += HandleSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= HandleSceneLoaded;
    }

    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (isPlayingMinigame)
        {
            //handle coming back from minigame
        }
    }

    public void SetMinigame(Minigames minigameId)
    {
        this.currentMinigame = minigameId;
        IsPlayingMinigame = true;
    }

    public void EndAndExitMinigame(int minigameScore)
    {
        currentMinigameScore = minigameScore;
        DelayedSceneLoad();
    }

    private void DelayedSceneLoad()
    {
        StartCoroutine(DelayedMenuLoadRoutine());
    }

    private IEnumerator DelayedMenuLoadRoutine()
    {
        yield return new WaitForSecondsRealtime(menuLoadDelay);
        Time.timeScale = 1.0F;
        SceneManager.LoadScene(GlobalVariables.mainScene);
    }

    private void HandlePlayerDataInit()
    {
        if (alwaysInitPlayerDataOnStart)
        {
            InitNewSaveFile();
        }
        else
        {
            if (PlayerDataSerializer.SaveExists())
            {
                PlayerDataSerializer.LoadFromFile();
            }
            else
            {
                InitNewSaveFile();
            }
        }
    }

    private void InitNewSaveFile()
    {
        PlayerData.Instance = new PlayerData();

        PlayerData.Instance.Money = 200;
        PlayerData.Instance.Level = 1;
        PlayerData.Instance.Experience = 0;
        PlayerData.Instance.ExpToLevel = 10;
        PlayerData.Instance.CurrentDay = 1;
        PlayerData.Instance.CurrentHour = 1;
        PlayerData.Instance.UnlockedUpgrades = new List<string>();
        PlayerData.Instance.ParametersData = initialParametersData;
    }
}
