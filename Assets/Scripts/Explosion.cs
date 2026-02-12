using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifetime = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifetime -=Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
            lifetime = 1;
        }
    }
}
