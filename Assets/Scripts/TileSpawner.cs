using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using System.Buffers.Text;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class TileSpawner : MonoBehaviour
{
    //Tile prefab
    public List<GameObject> tiles;
    public GameObject tilePrefab;
    private GameObject spawnedTiles;
    public TileBehaviour tileScript;

    //Game manager scripts
    public TileSpeedManager speedScript;
    public ScoreCounter scoreCounter;

    //Tile spawn timer
    private float spawnTimer;
    public float timerTime;
    public bool spawned = false;

    //Timer visualization
    public Slider timerVisuals;

    //Tile hitbox check
    public float hitboxY = -3f;
    public float hitboxHeight = 0.9f;

    //Flash feedback
    public SpriteRenderer flashVisual;
    public SpriteRenderer flashGradient;
    public float fade = 0;
    private bool fadeOut = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = timerTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Counts down after a tile desawn
        if (!spawned)
        {
            spawnTimer -= Time.deltaTime;

            //Visualize countdown on slider
            timerVisuals.value = spawnTimer / timerTime;
        }
        else
        {
            //Zero slider value if inactive
            timerVisuals.value = 0;
        }

        //When countdown hits zero
        if (spawnTimer <= 0)
        {
            //Spawn tile
            spawned = true;
            spawnedTiles = Instantiate(tilePrefab, transform.position, transform.rotation);

            //Add to list
            tiles.Add(spawnedTiles);

            //Reset timer
            spawnTimer = timerTime;

            //Debug.Log("Timer trigger");
        }

        //For each tile in list (there's only one at a time right now)
        for (int i = tiles.Count - 1; i >= 0; i--)
        {
            //Get tile behaviour script
            TileBehaviour tile = tiles[i].GetComponent<TileBehaviour>();

            //Set tile speed
            tile.speed = speedScript.tileSpeed;

            //If tile hits bottom of the screen
            if (tile.isOffScreen)
            {
                //Destroy tile
                Destroy(tiles[i]);

                //Remove from list
                tiles.RemoveAt(i);

                //Set random timer before respawning (Fall speed based)
                timerTime = Random.Range(2 / speedScript.tileSpeed, 10 / speedScript.tileSpeed);
                spawnTimer = timerTime;

                //Disable spawn state
                spawned = false;

                //Deduct score
                scoreCounter.DeductScore();
            }
        }

        //After properly hitting a tile 
        if (fadeOut)
        {
            //Fade out opacity float
            fade -= Time.deltaTime*3;

            //Direct tile feedback fade out
            Color col = new Color(1, 1, 1, fade);
            flashVisual.color = col;

            //Column gradient fade out
            Color colG = new Color(1, 1, 1, fade/3);
            flashGradient.color = colG;
        }
        //When opacity hits zero
        if (fade <= 0)
        {
            //Disable fade out
            fadeOut = false;
            //Reset float in case
            fade = 0;
        }

        //Debug
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
        //For each tile in list
        for (int i = tiles.Count - 1; i >= 0; i--)
        {
            //Check each tile's y position
            float tileY = tiles[i].transform.position.y;
            //Debug.Log(tileY);

            //When tile position overlap with hitbox check
            if (Mathf.Abs(tileY - hitboxY) <= hitboxHeight)
            {
                //Debug.Log("Hit");

                //Destroy tile
                Destroy(tiles[i]);
                tiles.RemoveAt(i);

                //Set random timer before respawning(Fall speed based)
                timerTime = Random.Range(2 / speedScript.tileSpeed, 10 / speedScript.tileSpeed);
                spawnTimer = timerTime;

                //Disable spawn state
                spawned = false;

                //Add score
                scoreCounter.AddScore();

                //Initiate fade out
                fadeOut = true;
                fade = 1;
            }
        }
    }
}
