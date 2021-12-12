using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Field : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameController gameController;
    private int idx;
    private bool isColored;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        idx = Convert.ToInt32(this.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameController.PickedField(idx);
        if (isColored)
            Debug.Log("");
            // GetComponent<UnityEngine.UI.Image>().overrideSprite = //custom
        else
            GetComponent<UnityEngine.UI.Image>().overrideSprite =
                Resources.Load<Sprite>(Path.Combine("Plants", gameController.pickedColor)); // todo change to simpler

        isColored ^= isColored;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // abc 
    }
}