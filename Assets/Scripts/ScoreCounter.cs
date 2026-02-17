using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int scoreCount = 0; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreCount.ToString();
    }

    public void AddScore()
    {
        scoreCount++;
    }
    public void DeductScore()
    {
        if (scoreCount != 0)
            scoreCount--;
    }

}
