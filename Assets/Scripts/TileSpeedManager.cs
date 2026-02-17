using UnityEngine;

public class TileSpeedManager : MonoBehaviour
{
    public float tileSpeed = 5f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpeedChange(float s)
    {
        tileSpeed = s;
        Debug.Log(s);
    }
}
