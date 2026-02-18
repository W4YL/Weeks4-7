using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    //Get TextMeshPro object
    public TextMeshProUGUI score;

    //Score
    public int scoreCount = 0; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Set text to score count
        score.text = scoreCount.ToString();
    }

    public void AddScore()
    {
        //Increase score
        scoreCount++;
    }
    public void DeductScore()
    {
        //Decrease score if above 0
        if (scoreCount !>= 0)
            scoreCount -= 3;

        //Lock score at 0 if going below
        if (scoreCount <= 0)
            scoreCount = 0;
    }

}
