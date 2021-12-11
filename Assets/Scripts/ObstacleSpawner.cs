using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject trash;
    [SerializeField] private GameObject animal;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndSpawn());
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    void Spawn()
    {
        var offset = Random.Range(-4, 4);
        var spawnPosition = gameObject.transform.position + new Vector3(offset, 0, 0);
        var spawnedObject = Instantiate(DrawObjectToSpawn(), spawnPosition, Quaternion.identity);
        var obstacle = spawnedObject.GetComponent<Obstacle>();
        obstacle.Shoot(time);
    }

    IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            var timeToWait = Random.Range(0.2f, 2f);
            yield return new WaitForSeconds(timeToWait);
            Spawn();
        }
    }

    GameObject DrawObjectToSpawn()
    {
        GameObject objectToSpawn;
        var r = Random.Range(0, 100);
        if (r < 15)
            objectToSpawn = obstacle;
        else if (r < 72)
            objectToSpawn = trash;
        else
            objectToSpawn = animal;
        return objectToSpawn;
    }
}