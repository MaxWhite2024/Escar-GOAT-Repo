using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopBehavior : MonoBehaviour
{
    public enum UpgradeType
    {
        SPEED, NUMBER, ATTACK, INCOME, LIFE
    };

    private void UpgradeStat(UpgradeType upgradeTypeToUpgrade)
    {
        //upgrade the appropriate player stat and increase the appropriate upgrade cost
        switch (upgradeTypeToUpgrade)
        {
            case UpgradeType.SPEED:
                //if player has enough money to buy speed upgrade,...
                if (PlayerStats.currencyCount >= PlayerStats.speedUpgradeCost)
                {
                    //decrement player currency
                    PlayerStats.currencyCount -= PlayerStats.speedUpgradeCost;

                    //upgrade speed
                    PlayerStats.movementSpeed += 2;

                    //increase speed upgrade cost
                    PlayerStats.speedUpgradeCost *= 2;
                }
                
                break;
            case UpgradeType.NUMBER:
                //if player has enough money to buy number upgrade,...
                if (PlayerStats.currencyCount >= PlayerStats.numberUpgradeCost)
                {
                    //decrement player currency
                    PlayerStats.currencyCount -= PlayerStats.numberUpgradeCost;

                    //upgrade speed
                    PlayerStats.shotsPerSecond += 2;

                    //increase number upgrade cost
                    PlayerStats.numberUpgradeCost *= 2;
                }

                break;
            case UpgradeType.ATTACK:
                //if player has enough money to buy attack upgrade,...
                if (PlayerStats.currencyCount >= PlayerStats.attackUpgradeCost)
                {
                    //decrement player currency
                    PlayerStats.currencyCount -= PlayerStats.attackUpgradeCost;

                    //upgrade damage
                    PlayerStats.projectileDamage += 1;

                    //increase attack upgrade cost
                    PlayerStats.attackUpgradeCost *= 2;
                }

                break;
            case UpgradeType.INCOME:
                //if player has enough money to buy income upgrade,...
                if (PlayerStats.currencyCount >= PlayerStats.inductionUpgradeCost)
                {
                    //decrement player currency
                    PlayerStats.currencyCount -= PlayerStats.inductionUpgradeCost;

                    //upgrade income
                    PlayerStats.coinPickupRange += 2;

                    //increase income upgrade cost
                    PlayerStats.inductionUpgradeCost *= 2;
                }

                break;
            case UpgradeType.LIFE:
                //if player has enough money to buy income upgrade,...
                if (PlayerStats.currencyCount >= PlayerStats.loveUpgradeCost)
                {
                    //decrement player currency
                    PlayerStats.currencyCount -= PlayerStats.loveUpgradeCost;

                    //upgrade income
                    PlayerStats.playerHealth += 1;

                    //increase income upgrade cost
                    PlayerStats.loveUpgradeCost *= 2;
                }

                break;
        }

        //Debug print player stats DELETE WHEN NOT DEBUGGING
        PlayerStats.PrintStats();
    }

    public void UpgradeSpeed()
    {
        UpgradeStat(UpgradeType.SPEED);
    }

    public void UpgradeNumber()
    {
        UpgradeStat(UpgradeType.NUMBER);
    }

    public void UpgradeAttack()
    {
        UpgradeStat(UpgradeType.ATTACK);
    }

    public void UpgradeInduction()
    {
        UpgradeStat(UpgradeType.INCOME);
    }

    public void UpgradeLove()
    {
        UpgradeStat(UpgradeType.LIFE);
    }

    public void Buy5Shells()
    {
        PlayerStats.shellCount += 5;
    }

    public void Buy10Shells()
    {
        PlayerStats.shellCount += 10;
    }

    public void Buy50Shells()
    {
        PlayerStats.shellCount += 50;
    }
}
