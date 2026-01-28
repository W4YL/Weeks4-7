using UnityEngine;
using UnityEngine.InputSystem;

public class UiDemo : MonoBehaviour
{
    SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            changeColor();
        }
    }

    public void changeColor()
    {
        sr.color = Random.ColorHSV();
    }

    public void setSize(float size)
    {
        transform.localScale = Vector3.one * size;
    }
}
