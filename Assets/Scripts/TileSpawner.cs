using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public List<GameObject> tiles;
    public GameObject tilePrefab;
    private GameObject spawnedTiles;
    public TileBehaviour tileScript;
    public TileSpeedManager speedScript;

    private float spawnTimer;
    public float timerTime;
    public bool spawned = false;

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

            Debug.Log("Timer trigger");
        }

        for (int i = tiles.Count - 1; i >= 0; i--)
        {
            TileBehaviour tile = tiles[i].GetComponent<TileBehaviour>();
            tile.speed = speedScript.tileSpeed;

            if (tile.isOffScreen)
            {
                Destroy(tiles[i]);
                tiles.Remove(tile.gameObject);

                timerTime = Random.Range(0.1f, 10f/speedScript.tileSpeed);
                spawnTimer = timerTime;
                spawned = false;
            }
        }
    }
}
