using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameCompletedScreen : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI points;
    [SerializeField]
    private TextMeshProUGUI rewards;
    [SerializeField]
    private GameObject screenObject;
    [SerializeField]
    private Button closeThisButton;

    public void ShowScreen(string title, string points, string rewards)
    {
        this.title.text = title;
        this.points.text = points;
        this.rewards.text = rewards;

        this.screenObject.SetActive(true);
    }

    private void OnEnable()
    {
        closeThisButton.onClick.AddListener(CloseWindow);
    }

    private void OnDisable()
    {
        closeThisButton.onClick.RemoveListener(CloseWindow);
    }

    private void CloseWindow()
    {
        screenObject.gameObject.SetActive(false);
    }
}
