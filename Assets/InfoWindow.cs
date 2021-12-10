using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject windowUi;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private Button closeWindowButton;

    private static InfoWindow instance;
    public static InfoWindow Instance { get => instance; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        closeWindowButton.onClick.AddListener(CloseWindow);
    }

    private void OnDisable()
    {
        closeWindowButton.onClick.RemoveListener(CloseWindow);
    }

    private void CloseWindow()
    {
        windowUi.SetActive(false);
    }

    public void ShowInfo(string info)
    {
        this.text.text = info;
        windowUi.SetActive(true);
    }
}
