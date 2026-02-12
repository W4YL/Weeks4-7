using UnityEngine;

public class CarObject : MonoBehaviour
{
    public float speed = 1;
    public SpriteRenderer spriteRenderer;
    public Transform frogTr;

    public GameObject explosion;
    private float timer = 1;
    public float timerTime = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 newPos = transform.position;
        newPos.x -= speed * Time.deltaTime;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < -80)                         
        {
            Destroy(gameObject);
        }

        transform.position = newPos;

        if (spriteRenderer.bounds.Contains(frogTr.position))
        {
            Debug.Log("Conditional achieved");

            Vector2 deathPosition = frogTr.position;

            Instantiate(explosion, deathPosition, Quaternion.identity);

            Vector2 newFrogPos = frogTr.position;
            newFrogPos = new Vector2(0, -4);
            frogTr.position = newFrogPos;
        }
    }
}
