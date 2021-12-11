using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MinigameLaunchWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject windowUi;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private Button closeWindowButton;
    [SerializeField]
    private Button launchMinigameButton;

    private Minigame selectedMinigame;

    private void OnEnable()
    {
        launchMinigameButton.onClick.AddListener(LaunchMinigame);
        closeWindowButton.onClick.AddListener(CloseWindow);
    }

    private void OnDisable()
    {
        launchMinigameButton.onClick.RemoveListener(LaunchMinigame);
        closeWindowButton.onClick.RemoveListener(CloseWindow);
    }

    public void ShowMinigame(Minigame minigame)
    {
        this.selectedMinigame = minigame;
        ShowInfo(selectedMinigame.MinigameDescription, selectedMinigame.MinigameName);

    }

    private void LaunchMinigame()
    {
        GlobalDataTransmitter.Instance.SetMinigame(this.selectedMinigame.MinigameId);
        SceneManager.LoadScene(this.selectedMinigame.MinigameScene);
    }

    private void CloseWindow()
    {
        windowUi.SetActive(false);
    }

    public void ShowInfo(string info, string title)
    {
        this.titleText.text = title;
        this.text.text = info;
        windowUi.SetActive(true);
    }
}