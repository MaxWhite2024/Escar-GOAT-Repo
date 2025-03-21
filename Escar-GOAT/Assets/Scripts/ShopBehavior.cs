using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopBehavior : MonoBehaviour
{
    [SerializeField] private int speedUpgradeCost = 1;
    [SerializeField] private int numberUpgradeCost = 1;
    [SerializeField] private int attackUpgradeCost = 1;
    [SerializeField] private int inductionUpgradeCost = 1;
    [SerializeField] private int loveUpgradeCost = 1;

    public enum UpgradeType
    {
        SPEED, NUMBER, ATTACK, INDUCTION, LOVE
    };

    private void UpgradeStat(UpgradeType upgradeTypeToUpgrade)
    {
        switch (upgradeTypeToUpgrade)
        {
            case UpgradeType.SPEED:
                PlayerStats.movementSpeed *= 2;
                speedUpgradeCost *= 2;
                break;
            case UpgradeType.NUMBER:
                PlayerStats.numberOfProjectilesPerShot *= 2;
                numberUpgradeCost *= 2;
                break;
            case UpgradeType.ATTACK:
                PlayerStats.shotsPerSecond *= 2;
                attackUpgradeCost *= 2;
                break;
            case UpgradeType.INDUCTION:
                PlayerStats.coinPickupRange *= 2;
                inductionUpgradeCost *= 2;
                break;
            case UpgradeType.LOVE:
                PlayerStats.maxHealth *= 2;
                loveUpgradeCost *= 2;
                break;
        }
    }

    public void UpgradeSpeed()
    {
        UpgradeStat(UpgradeType.SPEED);
        PlayerStats.PrintStats();
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
