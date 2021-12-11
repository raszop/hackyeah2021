using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool dragging;
    private float distance;
    private Score score;


    private void Start()
    {
        var scoreGM = GameObject.Find("GameController");
        score = scoreGM.GetComponent<Score>();
    }

    private void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            if (rayPoint.x > 4)
                transform.position = new Vector3(4, transform.position.y, transform.position.z);
            else if (rayPoint.x < -4)
                transform.position = new Vector3(-4, transform.position.y, transform.position.z);
            else
            {
                transform.position = new Vector3(rayPoint.x, transform.position.y, transform.position.z);
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("trash"))
        {
            Debug.Log("good touched");
            Destroy(collision.gameObject);
            score.Plus();
        }

        if (collision.gameObject.CompareTag("animal"))
        {
            Debug.Log("bad touched");
            Destroy(collision.gameObject);
            score.Minus(3);
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("end touched");
            score.EndGame();
        }
    }

    void OnMouseDown()
    {
        dragging = true;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    void OnMouseUp()
    {
        dragging = false;
    }
}