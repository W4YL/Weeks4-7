using UnityEngine;

public class Toggle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSquare()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);

        ////If game object is turned on
        //if (gameObject.activeInHierarchy)
        //{
        //    gameObject.SetActive(false);
        //}
        ////Otherwise
        //else
        //{
        //    gameObject.SetActive(true);
        //}
    }
}
