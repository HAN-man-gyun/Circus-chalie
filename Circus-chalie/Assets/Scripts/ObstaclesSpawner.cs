using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private int count = 10;
    // Start is called before the first frame update

    public float timeBetSpawnMin = 3.25f;
    public float timeBetSpawnMax = 5.25f;
    private float timeBetSpawn;

    private float xPos = 26f;
    private float yPos = -2.86f;

    private GameObject[] obstacles;
    private int currentIndex;

    private Vector2 poolPosition = new Vector2(0, -15);
    private float lastSpawnTime;

    void Start()
    {
        obstacles = new GameObject[count];

        for(int i = 0; i < count; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab, poolPosition, Quaternion.identity);
            obstacles[i].transform.SetParent(transform);
        }
        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameover)
        {
            return;
        }
        if(Time.time >= lastSpawnTime+timeBetSpawn)
        {
            lastSpawnTime = Time.time;

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            obstacles[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;
            Debug.LogFormat("{0}ÀÌ´Ù.", currentIndex);
            
            
            if(currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
