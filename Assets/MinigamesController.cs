using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesController : MonoBehaviour
{
    [SerializeField]
    private MinigameLaunchWindow minigameLaunchWindow;
    [SerializeField]
    private List<Minigame> minigames;

    private static MinigamesController instance;
    public static MinigamesController Instance { get => instance; }

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

    public void PreviewMinigame(Minigames minigameId)
    {
        minigameLaunchWindow.ShowMinigame(minigames.Find(x => x.MinigameId == minigameId));
    }
}

public enum Minigames
{
    SeaTrash = 0,
    Consumptionism = 1
}

[System.Serializable]
public class Minigame
{
    public Minigames MinigameId;
    public string MinigameScene;
    public string MinigameName;
    public string MinigameDescription;
}