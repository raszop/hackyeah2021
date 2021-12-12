using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Species : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameController.pickedColor = this.name;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // abc 
    }
}