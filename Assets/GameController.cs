using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject colorPicker;

    private List<GameObject> colorsToPick;
    public string pickedColor;
    public string[] pickedFields;
    
    // Start is called before the first frame update
    void Start()
    {
        pickedFields = new string[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickedField(int idx)
    {
        if (pickedFields[idx] == null)
            Debug.Log("remove");
        else if (pickedColor != null)
        {
            pickedFields[idx] = pickedColor;
            pickedColor = null;
        }
    }
}
