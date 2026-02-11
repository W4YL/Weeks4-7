using UnityEngine;

public class CarObject : MonoBehaviour
{
    public float speed = 1;
    public SpriteRenderer spriteRenderer;
    public Transform frogTr;

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
            newPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width + 80, screenPos.y));
        }

        transform.position = newPos;

        if (spriteRenderer.bounds.Contains(frogTr.position))
        {
            Debug.Log("Conditional achieved");
            Vector2 newFrogPos = frogTr.position;
            newFrogPos = new Vector2(0, -4);
            frogTr.position = newFrogPos;
        }
    }
}
