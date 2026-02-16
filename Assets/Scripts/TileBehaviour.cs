using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public TileSpawner tileSpawner;
    public float speed;
    public bool isOffScreen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos.y -= speed * Time.deltaTime;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.y < -20)
        {
            isOffScreen = true;
        }

        transform.position = newPos;
    }
}
