using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;

public class Person : MonoBehaviour
{
    private bool dragging;
    private float distance;
    private Score score;


    [SerializeField] [Range(7f, 10f)] private float speed;
    private List<GameObject> allGoals;
    private bool isGrabbed;


    void Start()
    {
        allGoals = GetAllGoals();
        var scoreGM = GameObject.Find("GameController");
        score = scoreGM.GetComponent<Score>();
    }


    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        isGrabbed = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint = new Vector3(rayPoint.x, transform.position.y, rayPoint.z);

            transform.position = rayPoint;
        }
        else
        {
            GameObject bestGoal = GetBestGoal();
            if (bestGoal == null) return;
            float step = speed * Time.fixedDeltaTime; // calculate distance to move
            transform.position =
                Vector3.MoveTowards(gameObject.transform.position, bestGoal.GetComponent<Transform>().position, step);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("good"))
        {
            Debug.Log("good touched");
            Destroy(gameObject);
            score.Plus();
        }
        else if (collision.gameObject.CompareTag("treat"))
        {
            Debug.Log("treat touched");
            Destroy(gameObject);
            score.Minus();
        }
    }

    GameObject GetBestGoal()
    {
        float? nearestGoalScore = null;
        GameObject bestGoal = null;
        foreach (var goal in allGoals)
        {
            if (CanGo(goal.tag))
            {
                float distance = Vector3.Distance(goal.GetComponent<Transform>().position, transform.position);
                float score = CountScore(distance, goal.tag);
                if (nearestGoalScore == null || score < nearestGoalScore)
                {
                    nearestGoalScore = distance;
                    bestGoal = goal;
                }
            }
        }

        return bestGoal;
    }

    private List<GameObject> GetAllGoals()
    {
        var allGoals = GameObject.FindGameObjectsWithTag("good");
        return allGoals.Concat(GameObject.FindGameObjectsWithTag("treat")).ToList();
    }

    float CountScore(float distance, string tag)
    {
        float score = 1;

        if (tag == "treat")
            if (tag == "treat")
            {
                score = 1.15f;
            }

        return distance / score;
    }

    bool CanGo(string tag)
    {
        if (isGrabbed && tag == "good" || tag == "treat")
            return true;
        return false;
    }
}