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
        if (PlayerStats.scoreCount > previousScore)
        {
            previousScore = PlayerStats.scoreCount;
            if (PlayerStats.scoreCount > highScore.highscore)
                highScore.highscore = PlayerStats.scoreCount;
        }
    }
}
