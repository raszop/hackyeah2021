using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject person;

    [SerializeField]
    private float spawnInterval = 5f;
    private float timeCounter;
    [SerializeField][Range(150,200)]
    float radius = 350f;

    void Start()
    {
        SpawnOnCircle(9);
    }

    void Update()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= spawnInterval)
        {
            var peopleToSpawn = Random.Range(0, 5);
            SpawnOnCircle(peopleToSpawn);
            timeCounter = 0.0f;
        }

        if (spawnInterval > 0.5f)
            spawnInterval -= Time.deltaTime * 0.04f;
    }

    void SpawnOnCircle(int peopleToSpawn = 5, int difficulty=1)
    {
        for (int i = 0; i < peopleToSpawn ; i++)
        {
            var offset = Random.Range(30, 75);
            float angle = (i * Mathf.PI*2f / peopleToSpawn) + offset;
            Vector3 newPos = new Vector3(Mathf.Cos(angle)*radius, 6, Mathf.Sin(angle)*radius);
            Instantiate(person, newPos, Quaternion.identity);
        }
    }

    void SpawnPerson(Vector3 newPos)
    {
        Instantiate(person, newPos, Quaternion.identity);

    }
}
