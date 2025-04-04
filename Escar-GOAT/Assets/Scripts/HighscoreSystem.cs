using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreSystem : MonoBehaviour
{
    public HighscoreObject highScore;
    private int previousScore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.ScoreCount > previousScore)
        {
            previousScore = PlayerStats.ScoreCount;
            if (PlayerStats.ScoreCount > highScore.highscore)
                highScore.highscore = PlayerStats.ScoreCount;
        }
    }
}
