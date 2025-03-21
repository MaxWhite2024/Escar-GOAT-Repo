using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopBehavior : MonoBehaviour
{
    public enum UpgradeType
    {
        SPEED, NUMBER, ATTACK, INDUCTION, LOVE
    };

    private void UpgradeStat(UpgradeType upgradeTypeToUpgrade)
    {
        //upgrade the appropriate player stat and increase the appropriate upgrade cost
        switch (upgradeTypeToUpgrade)
        {
            case UpgradeType.SPEED:
                PlayerStats.movementSpeed *= 2;
                PlayerStats.speedUpgradeCost *= 2;
                break;
            case UpgradeType.NUMBER:
                PlayerStats.numberOfProjectilesPerShot *= 2;
                PlayerStats.numberUpgradeCost *= 2;
                break;
            case UpgradeType.ATTACK:
                PlayerStats.shotsPerSecond *= 2;
                PlayerStats.attackUpgradeCost *= 2;
                break;
            case UpgradeType.INDUCTION:
                PlayerStats.coinPickupRange *= 2;
                PlayerStats.inductionUpgradeCost *= 2;
                break;
            case UpgradeType.LOVE:
                PlayerStats.maxHealth *= 2;
                PlayerStats.loveUpgradeCost *= 2;
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
        UpgradeStat(UpgradeType.INDUCTION);
    }

    public void UpgradeLove()
    {
        UpgradeStat(UpgradeType.LOVE);
    }
}
