using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public List<GameObject> tiles;
    public GameObject tilePrefab;
    private GameObject spawnedTiles;
    public TileBehaviour tileScript;
    public TileSpeedManager speedScript;
    public ScoreCounter scoreCounter;

    private float spawnTimer;
    public float timerTime;
    public bool spawned = false;

    public float hitboxY = -3f;
    public float hitboxHeight = 0.9f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = timerTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned)
        {
            spawnTimer -= Time.deltaTime;
        }

        if (spawnTimer <= 0)
        {
            spawned = true;
            spawnedTiles = Instantiate(tilePrefab, transform.position, transform.rotation);

            tiles.Add(spawnedTiles);
            spawnTimer = timerTime;

            //Debug.Log("Timer trigger");
        }

        for (int i = tiles.Count - 1; i >= 0; i--)
        {
            TileBehaviour tile = tiles[i].GetComponent<TileBehaviour>();
            tile.speed = speedScript.tileSpeed;

            if (tile.isOffScreen)
            {
                Destroy(tiles[i]);
                tiles.RemoveAt(i);

                timerTime = Random.Range(2 / speedScript.tileSpeed, 10 / speedScript.tileSpeed);
                spawnTimer = timerTime;
                spawned = false;

                scoreCounter.DeductScore();
            }
        }

        //for (int i = tiles.Count - 1; i >= 0; i--)
        //{
        //    float tileY = tiles[i].transform.position.y;

        //    if (Mathf.Abs(tileY - hitboxY) <= hitboxHeight)
        //    {
        //        Debug.Log("In range");
        //    }

        //    if (tileY < hitboxY)
        //    {
        //        Debug.Log("Below hitbox");
        //    }
        //    Debug.Log(tileY);
        //}
    }

    public void HitFunction()
    {
        for (int i = tiles.Count - 1; i >= 0; i--)
        {
            float tileY = tiles[i].transform.position.y;
            //Debug.Log(tileY);

            if (Mathf.Abs(tileY - hitboxY) <= hitboxHeight)
            {
                //Debug.Log("Hit");
                Destroy(tiles[i]);
                tiles.RemoveAt(i);

                timerTime = Random.Range(2 / speedScript.tileSpeed, 10 / speedScript.tileSpeed);
                spawnTimer = timerTime;
                spawned = false;

                scoreCounter.AddScore();
            }
        }
    }
}
