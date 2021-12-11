using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SetMinigame(Minigames minigameId)
    {
        this.currentMinigame = minigameId;
        IsPlayingMinigame = true;
    }
}
