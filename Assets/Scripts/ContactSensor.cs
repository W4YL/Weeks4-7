using UnityEngine;
using UnityEngine.Events;

public class ContactSensor : MonoBehaviour
{
    public SpriteRenderer hazard;
    public bool isInHazard = false;
    public UnityEvent OnEnterSensor;
    public UnityEvent OnExitSensor;
    public UnityEvent<float> OnRandomNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hazard.bounds.Contains(transform.position))
        {
            if (isInHazard)
            {
                //Still in the hazard
            }
            else
            {
                //Entered hazard
                Debug.Log("Entered the hazard");
                OnEnterSensor.Invoke();
                isInHazard = true;
            }
        }
        else
        {
            if (isInHazard)
            {
                //Exited the hazard
                //do something
                Debug.Log("Exited the hazard");
                OnExitSensor.Invoke();
                OnRandomNumber.Invoke(Random.Range(0,10));
                isInHazard = false;
            }
            else
            {
                //Not in hazard
            }
        }
    }

    public void ShowNumber()
    {
        Debug.Log("number");
    }
}
