using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float t = 0;
    public AnimationCurve curve;
    private Vector2 movePos;
    private Vector2 currentPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movePos = transform.position;
        currentPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !EventSystem.current.IsPointerOverGameObject() && movePos == (Vector2)transform.position)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            movePos = mousePos;
            t = 0;
        }

        if (movePos != (Vector2)transform.position)
        {
            t += Time.deltaTime;
        }

        transform.position = Vector2.Lerp(currentPos, movePos, curve.Evaluate(t));
    }
}
