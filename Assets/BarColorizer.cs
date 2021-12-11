using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarColorizer : MonoBehaviour
{
    [SerializeField]
    private List<ColorLevel> colorLevels;
    [SerializeField]
    private Image imageToAdjust;

    public void AdjustLevel(float value)
    {
        imageToAdjust.color = GetColorByValue(value);
    }

    private Color GetColorByValue(float value)
    {
        Color targetColor = Color.white;

        foreach(ColorLevel cl in colorLevels)
        {
            if (value >= cl.EdgeLevel)
            {
                targetColor = cl.Color;
            }
            else
                break;
        }

        return targetColor;
    }
}

[System.Serializable]
public class ColorLevel
{
    public Color Color;
    public float EdgeLevel;
}
