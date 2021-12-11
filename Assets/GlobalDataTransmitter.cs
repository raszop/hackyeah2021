using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GlobalDataTransmitter : MonoBehaviour
{
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
        if(instance == null)
        {
            instance = this;
        }else
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
        if(isPlayingMinigame)
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
        SceneManager.LoadScene(GlobalVariables.mainScene);
    }
}
