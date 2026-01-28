using UnityEngine;

public class SpinButton : MonoBehaviour
{
    float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setRotation(float speed)
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z += speed * Time.deltaTime;
        transform.eulerAngles = newRotation;
    }
}
