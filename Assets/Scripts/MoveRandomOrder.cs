using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomOrder : MonoBehaviour
{
    public float speed = 2f;
    private float step;

    private Vector3 basestartpoint;
    private Vector3 destination;

    private Vector3 start;


    void Start()
    {
        start = transform.localPosition;
        PickNewRandomDestination();
    }

    void Update()
    {
        transform.localPosition =
            Vector3.MoveTowards(gameObject.transform.position, destination, speed * Time.fixedDeltaTime);

        step += Time.fixedDeltaTime;

        if (step > 1f)
        {
            start = destination;
            PickNewRandomDestination();
            step = 0.0f;
        }
    }

    void PickNewRandomDestination()
    {
        float radius = 8f;
        var originPoint = start;
        originPoint.x += Random.Range(-radius, radius);
        originPoint.z += Random.Range(-radius, radius);
        destination = originPoint;
    }
}