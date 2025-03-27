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
    public static int numberOfProjectilesPerShot; //NUMBER
    public static int shotsPerSecond; //ATTACK
    public static float coinPickupRange; //INDUCTION
    public static int maxHealth; //LOVE

    //upgrade cost stats
    public static int speedUpgradeCost;
    public static int numberUpgradeCost;
    public static int attackUpgradeCost;
    public static int inductionUpgradeCost;
    public static int loveUpgradeCost;

    //player coins
    public static int currencyCount;

    public static void PrintStats()
    {
        Debug.Log("||||| Current Player Stats ||||| \n" + 
        "Speed = " + movementSpeed + ". | " +
        "Number = " + numberOfProjectilesPerShot + ". | " +
        "Attack = " + shotsPerSecond + ". | " +
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
        numberOfProjectilesPerShot = 1;
        shotsPerSecond = 1;
        coinPickupRange = 3f;

        speedUpgradeCost = 1;
        numberUpgradeCost = 1;
        attackUpgradeCost = 1;
        inductionUpgradeCost = 1;
        loveUpgradeCost = 10;
            
        currencyCount = 0;
    }

}

