using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopBehavior : MonoBehaviour
{
    [SerializeField] private List<Sprite> allCosmetics = new List<Sprite>();
    private int currentCosmeticIndex = 0;
    [SerializeField] private Image currentCosmeticImage;
    [SerializeField] private GameObject buyCosmeticButton;
    [SerializeField] private GameObject equipCosmeticButton;
    [SerializeField] private SpriteRenderer playerEquippedCosmeticImage;
    public enum UpgradeType
    {
        SIZE, NUMBER, ATTACK, INCOME, LIFE
    };

    //***** Upgrade Shop Functions *****
    private void UpgradeStat(UpgradeType upgradeTypeToUpgrade)
    {
        //upgrade the appropriate player stat and increase the appropriate upgrade cost
        switch (upgradeTypeToUpgrade)
        {
            case UpgradeType.SIZE:
                //if player has enough money to buy speed upgrade,...
                if (PlayerStats.currencyCount >= PlayerStats.sizeUpgradeCost)
                {
                    //decrement player currency
                    PlayerStats.currencyCount -= PlayerStats.sizeUpgradeCost;

                    //upgrade speed
                    PlayerStats.attackSize += .2f;

                    //increase speed upgrade cost
                    PlayerStats.sizeUpgradeCost *= 2;
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
                    PlayerStats.PlayerHealth += 1;

                    //increase income upgrade cost
                    PlayerStats.loveUpgradeCost *= 2;
                }

                break;
        }

        //Debug print player stats DELETE WHEN NOT DEBUGGING
        PlayerStats.PrintStats();
    }

    public void UpgradeSize()
    {
        UpgradeStat(UpgradeType.SIZE);
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

    //***** Premium Shop Functions *****
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

    //***** Cosmetic Shop Functions *****
    public void CycleCosmeticsRight()
    {
        //increment index with wrap-around
        if (currentCosmeticIndex == allCosmetics.Count - 1)
            currentCosmeticIndex = 0;
        else
            currentCosmeticIndex++;

        //change cosmetic shown
        DisplayCurrentCosmetic();

        //show the correct cosmetic button
        HandleCosmeticButtons();
    }

    public void CycleCosmeticsLeft()
    {
        //decrement index with wrap-around
        if (currentCosmeticIndex == 0)
            currentCosmeticIndex = allCosmetics.Count - 1;
        else
            currentCosmeticIndex--;

        //change cosmetic shown
        DisplayCurrentCosmetic();

        //show the correct cosmetic button
        HandleCosmeticButtons();
    }

    private void DisplayCurrentCosmetic()
    {
        //if current sprite is empty,...
        if (allCosmetics[currentCosmeticIndex] == null)
        {
            //make sprite transparent
            Color transparentColor = new Color(1, 1, 1, 0);
            currentCosmeticImage.color = transparentColor;
        }
        //else current sprite is NOT empty,...
        else
        {
            //make sprite opaque
            Color opaqueColor = new Color(1, 1, 1, 1);
            currentCosmeticImage.color = opaqueColor;
        }

        //set the current shown cosmetic to the cosmetic at currentCosmeticIndex in the allCosmetics list
        currentCosmeticImage.sprite = allCosmetics[currentCosmeticIndex];
    }

    private void HandleCosmeticButtons()
    {
        //if current cosmetic is owned,... 
        if (PlayerStats.ownedCosmetics.Contains(allCosmetics[currentCosmeticIndex]))
        {
            //show the "equip" button
            buyCosmeticButton.SetActive(false);
            equipCosmeticButton.SetActive(true);
        }
        //else cosmetic is NOT owned,...
        else
        {
            //show the "buy" button
            buyCosmeticButton.SetActive(true);
            equipCosmeticButton.SetActive(false);
        }
    }

    public void BuyCurrentCosmetic()
    {
        //if player has enough shells to buy current cosmetic,...
        if (PlayerStats.shellCount >= 5)
        {
            //add the cosmetic item to the player's owned cosmetics
            PlayerStats.ownedCosmetics.Add(allCosmetics[currentCosmeticIndex]);

            //subtract the cost from the player's shells
            PlayerStats.shellCount -= 5;

            //change the "buy" button to the "equip" button
            HandleCosmeticButtons();

        }
        //else,...
        else
        {
            //return 
            return;
        }
    }

    public void EquipCurrentCosmetic()
    {
        //switch currently equipped cosmetic
        playerEquippedCosmeticImage.sprite = allCosmetics[currentCosmeticIndex];

        //update cosmetic shown
        DisplayCurrentCosmetic();
    }
}
