using UnityEngine;

public class Spin : MonoBehaviour
{
    //Spin speed
    public float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Constant rotation
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z -= speed * Time.deltaTime;
        transform.eulerAngles = newRotation;
    }
}
