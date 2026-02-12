using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarSpawner : MonoBehaviour
{
    public GameObject spawnedCars;
    public GameObject frog;
    public float spawnTimer = 3;
    public float timerTime = 3;

    public List<GameObject> cars;

    public CarObject carScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            spawnedCars.GetComponent<CarObject>().frogTr = frog.transform;
            Vector2 spawnPos = transform.position;
            spawnTimer = timerTime;
            Instantiate(spawnedCars, spawnPos, Quaternion.identity);

            cars.Add(spawnedCars);
        }

    }
}
