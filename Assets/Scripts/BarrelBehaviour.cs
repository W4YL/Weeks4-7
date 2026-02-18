using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    public float t = 0;
    Vector2 newStartPos;
    Vector2 newEndPos;
    public AnimationCurve lerpCurve;

    public bool barrelImpact = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newEndPos = transform.position;
        newStartPos = transform.position;
        newStartPos.x += 10;
    }

    // Update is called once per frame
    void Update()
    {

        t += Time.deltaTime;
        transform.position = Vector2.Lerp(newStartPos, newEndPos, lerpCurve.Evaluate(t));

        if (t >= 1)
        {
            barrelImpact = true;
        }
    }
}
