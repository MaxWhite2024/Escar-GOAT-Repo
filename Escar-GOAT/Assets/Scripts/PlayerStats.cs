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

