using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceBarUi : MonoBehaviour
{
    [SerializeField]
    private Image expBar;
    [SerializeField]
    private TextMeshProUGUI level;
    [SerializeField]
    private TextMeshProUGUI exp;

    public void Repaint(int level, int exp, int expToLevel)
    {
        expBar.fillAmount = exp / expToLevel;
        this.level.text = level.ToString();
        this.exp.text = exp.ToString() + "/" + expToLevel.ToString();
    }
}
