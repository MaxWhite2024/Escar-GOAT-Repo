using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats Instance", menuName = "New Player Stats Instance")]
public class PlayerStats : ScriptableObject
{
    //base player stats
    public static float movementSpeed = 2f; //SPEED
    public static int numberOfProjectilesPerShot = 1; //NUMBER
    public static int shotsPerSecond = 1; //ATTACK
    public static float coinPickupRange = 3f; //INDUCTION
    public static int maxHealth = 3; //LOVE

    //upgrade cost stats
    public static int speedUpgradeCost = 1;
    public static int numberUpgradeCost = 1;
    public static int attackUpgradeCost = 1;
    public static int inductionUpgradeCost = 1;
    public static int loveUpgradeCost = 1;

    //player coins
    public static int currencyCount = 0;

    public static void PrintStats()
    {
        Debug.Log("||||| Current Player Stats ||||| \n" + 
        "Speed = " + movementSpeed + ". | " +
        "Number = " + numberOfProjectilesPerShot + ". | " +
        "Attack = " + shotsPerSecond + ". | " +
        "Induction = " + coinPickupRange + ". | " +
        "love = " + maxHealth + ".SS"
        );
    }
}

