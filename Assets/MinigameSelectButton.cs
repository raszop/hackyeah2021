using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameSelectButton : MonoBehaviour
{
    [SerializeField]
    private Minigames minigameId;
    [SerializeField]
    private Button button;

    private void OnEnable()
    {
        button.onClick.AddListener(PreviewMinigame);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(PreviewMinigame);
    }

    private void PreviewMinigame()
    {
        MinigamesController.Instance.PreviewMinigame(minigameId);
    }
}