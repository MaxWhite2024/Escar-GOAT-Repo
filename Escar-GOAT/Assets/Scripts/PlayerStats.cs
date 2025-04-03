using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats Instance", menuName = "New Player Stats Instance")]
public class PlayerStats : ScriptableObject
{
    //player health
    public static int playerHealth;

    //base player stats
    public static float movementSpeed; //SPEED
    public static int shotsPerSecond; //NUMBER
    public static int projectileDamage; //ATTACK
    public static float coinPickupRange; //INCOME
    public static int maxHealth; //LIVES

    //upgrade cost stats
    public static int speedUpgradeCost;
    public static int numberUpgradeCost;
    public static int attackUpgradeCost;
    public static int inductionUpgradeCost;
    public static int loveUpgradeCost;

    //player coins and shells
    public static int currencyCount = 0;
    public static int shellCount = 0;
    public static int scoreCount = 0;
    public static int highscoreCount = 0;

    //player owned cosmetics
    public static List<Sprite> ownedCosmetics = new List<Sprite>();

    public static void PrintStats()
    {
        Debug.Log("||||| Current Player Stats ||||| \n" + 
        "Speed = " + movementSpeed + ". | " +
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

        movementSpeed = 2;
        shotsPerSecond = 1;
        projectileDamage = 1;
        coinPickupRange = 3f;

        speedUpgradeCost = 1;
        numberUpgradeCost = 1;
        attackUpgradeCost = 1;
        inductionUpgradeCost = 1;
        loveUpgradeCost = 10;
            
        scoreCount = 0;
        currencyCount = 0;
    }

}

