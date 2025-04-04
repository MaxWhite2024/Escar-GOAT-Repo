using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Player Stats Instance", menuName = "New Player Stats Instance")]
public class PlayerStats : ScriptableObject
{
    //player health
    private static int playerHealth;
    
    public static UnityEvent onPlayerDamageTaken = new UnityEvent();

    public static int PlayerHealth
    {
        get { return playerHealth; }
        set
        {
            if(value < playerHealth)
            {
                onPlayerDamageTaken?.Invoke();
            }
            
            playerHealth = value;
        }
    }

    //base player stats
    public static float attackSize; //SIZE
    public static int shotsPerSecond; //NUMBER
    public static int projectileDamage; //ATTACK
    public static float coinPickupRange; //INCOME
    public static int maxHealth; //LIVES

    //upgrade cost stats
    public static int sizeUpgradeCost;
    public static int numberUpgradeCost;
    public static int attackUpgradeCost;
    public static int inductionUpgradeCost;
    public static int loveUpgradeCost;

    //player coins and shells
    public static int currencyCount = 0;
    public static int shellCount = 0;
    private static int scoreCount = 0;
    private static int previousScoreMilestons = 0;
    public static int highscoreCount = 0;
    
    public static UnityEvent onNewScoreMilestone = new UnityEvent();

    public static int ScoreCount
    {
        get { return scoreCount; }
        set
        {
            scoreCount = value;

            if ((scoreCount - previousScoreMilestons) / 100 > 0)
            {
                previousScoreMilestons = scoreCount;
                onNewScoreMilestone.Invoke();
            }
        }
    }

    //player owned cosmetics
    public static List<Sprite> ownedCosmetics = new List<Sprite>();

    public static void PrintStats()
    {
        Debug.Log("||||| Current Player Stats ||||| \n" + 
        "Size = " + attackSize + ". | " +
        "Number = " + shotsPerSecond + ". | " +
        "Attack = " + projectileDamage + ". | " +
        "Induction = " + coinPickupRange + ". | " +
        "love = " + playerHealth + ".SS"
        );
    }

    /// <summary>
    /// Resets the player's stats
    /// </summary>
    public static void ResetPlayer()
    {
        playerHealth = 1;

        attackSize = .3f;
        shotsPerSecond = 1;
        projectileDamage = 1;
        coinPickupRange = 3f;

        sizeUpgradeCost = 1;
        numberUpgradeCost = 1;
        attackUpgradeCost = 1;
        inductionUpgradeCost = 1;
        loveUpgradeCost = 10;
            
        scoreCount = 0;
        previousScoreMilestons = 0;
        currencyCount = 0;
    }

}

