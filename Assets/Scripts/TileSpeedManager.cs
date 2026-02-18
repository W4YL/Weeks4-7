using UnityEngine;

public class TileSpeedManager : MonoBehaviour
{
    //Global tile speed for each column
    public float tileSpeed = 5f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Slider reference
    public void SpeedChange(float s)
    {
        //Set speed to slider value
        tileSpeed = s;
        //Debug.Log(s);
    }
}
