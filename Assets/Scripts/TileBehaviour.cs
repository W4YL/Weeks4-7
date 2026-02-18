using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    //Get reference to spawner
    public TileSpawner tileSpawner;

    //Fall speed
    public float speed;

    //Off screen check
    public bool isOffScreen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Constant downwards velocity
        Vector2 newPos = transform.position;
        newPos.y -= speed * Time.deltaTime;

        //If tile goes off screen
        if (newPos.y < -5.5)
        {
            //Enable conditional for spawner to detect
            isOffScreen = true;
        }

        //Change transform position
        transform.position = newPos;
    }
}
