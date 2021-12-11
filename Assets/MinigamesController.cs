using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigamesController : MonoBehaviour
{
    [SerializeField]
    private GameCompletedScreen gameCompletedScreen;
    [SerializeField]
    private MinigameLaunchWindow minigameLaunchWindow;
    [SerializeField]
    private List<Minigame> minigames;
    [SerializeField]
    private List<MinigameReward> minigameRewards;

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += HandleSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= HandleSceneLoaded;
    }

    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(GlobalDataTransmitter.Instance.IsPlayingMinigame)
        {
            HandleRewarding();
        }
    }

    private void HandleRewarding()
    {
        StartCoroutine(GrantRewardsRoutine());
    }

    private IEnumerator GrantRewardsRoutine()
    {
        yield return new WaitForEndOfFrame();
        Minigames completedMinigame = GlobalDataTransmitter.Instance.CurrentMinigame;
        DisplayRewards(completedMinigame);
        GrantRewards(completedMinigame);

        ExperienceController.Instance.AddExp(GlobalDataTransmitter.Instance.CurrentMinigameScore);
        MoneyController.Instance.Money += GlobalDataTransmitter.Instance.CurrentMinigameScore;

        GlobalDataTransmitter.Instance.IsPlayingMinigame = false;
    }

    private void DisplayRewards(Minigames completedGame)
    {
        MinigameReward reward = minigameRewards.Find(x => x.MinigameId == completedGame);
        gameCompletedScreen.ShowScreen(
            minigames.Find(x => x.MinigameId == completedGame).MinigameName,
            "Punkty +" +GlobalDataTransmitter.Instance.CurrentMinigameScore,
            GeneratedRewardsList(reward.Rewards));
    }

    private void GrantRewards(Minigames completedGame)
    {
        MinigameReward reward = minigameRewards.Find(x => x.MinigameId == completedGame);

        foreach(ParameterAndValue param in reward.Rewards)
        {
            ParametersController.Instance.ApplyParameterChange(param.Parameter, param.Value);
        }

    }

    private string GeneratedRewardsList(List<ParameterAndValue> rewards)
    {
        string r = "";
        foreach(ParameterAndValue param in rewards)
        {
            r += ParametersController.Instance.GetParameterName(param.Parameter) + " -" + param.Value.ToString() + "\n";
        }
        return r;
    }
}

public enum Minigames
{
    SeaTrash = 0,
    Consumptionism = 1,
    Mastermind = 2
}

[System.Serializable]
public class Minigame
{
    public Minigames MinigameId;
    public string MinigameScene;
    public string MinigameName;
    public string MinigameDescription;
}

[System.Serializable]
public class MinigameReward
{
    public Minigames MinigameId;
    public List<ParameterAndValue> Rewards;
}

[System.Serializable]
public class ParameterAndValue
{
    public Parameters Parameter;
    public float Value;
}