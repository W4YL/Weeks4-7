using UnityEngine;

public class ClockFunctions : MonoBehaviour
{
    public float speed = 7;
    public float timer = 0;
    public float timerMax = 3;

    public AudioSource audioSource;
    public GameObject soundImage;
    public SpriteRenderer imageColor;
    private float imageFade = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate clock hand
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z -= speed * Time.deltaTime;
        transform.eulerAngles = newRotation;

        timer += Time.deltaTime;
        if (timer > timerMax)
        {
            timer = 0;
            audioSource.Play();
        }

        if (audioSource.isPlaying)
        {
            soundImage.SetActive(true);
            Color col = new Color(1, 1, 1, imageFade);
            imageColor.color = col;

            imageFade -= Time.deltaTime;
        }
        else
        {
            soundImage.SetActive(false);
            imageFade = 1;
        }
    }
}
