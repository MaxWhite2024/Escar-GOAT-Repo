using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private UserInput userInput;

    [Header("UI Variables")]
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI shellText;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    private bool isMenuOpen = false;
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject cosmeticsMenuUI;
    [SerializeField] private GameObject premiumShopUI;
    [SerializeField] private GameObject closedShopUI;

    [Header("Upgrade Text Variables")]
    [SerializeField] private TextMeshProUGUI speedUpgradeText;
    [SerializeField] private TextMeshProUGUI numberUpgradeText;
    [SerializeField] private TextMeshProUGUI attackUpgradeText;
    [SerializeField] private TextMeshProUGUI inductionUpgradeText;
    [SerializeField] private TextMeshProUGUI loveUpgradeText;

    private bool anyLogWarnings = false;

    private void Start()
    {
        //Resume game
        Resume();

        //if playerController has NOT been assigned,...
        if (!playerController)
        {
            //Log a warning
            Debug.LogWarning("Player Controller has not been assigned to Canvas | Please assign a PlayerController to the Player Controller variable");

            //make anyLogWarnings true
            anyLogWarnings = true;
        }

        //if coinText has NOT been assigned,...
        if (!coinText)
        {
            //Log a warning
            Debug.LogWarning("Coin Text has not been assigned to Canvas | Please assign a TextMeshProUGUI component to the Coin Text variable");

            //make anyLogWarnings true
            anyLogWarnings = true;
        }

        //if shellText has NOT been assigned,...
        if (!shellText)
        {
            //Log a warning
            Debug.LogWarning("Shell Text has not been assigned to Canvas | Please assign a TextMeshProUGUI component to the Shell Text variable");

            //make anyLogWarnings true
            anyLogWarnings = true;
        }

        //if userInput has NOT been assigned,...
        if (!userInput)
        {
            //Log a warning
            Debug.LogWarning("User Input has not been assigned to Canvas | Please assign a User Input component to the User Input variable");
             
            //make anyLogWarnings true
            anyLogWarnings = true;
        }

        //if playerHealthText has NOT been assigned,...
        if (!playerHealthText)
        {
            //Log a warning
            Debug.LogWarning("Player Health Text has not been assigned to Canvas | Please assign a TextMeshProUGUI component to the Pleayer Health Text variable");

            //make anyLogWarnings true
            anyLogWarnings = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if there are any log warnings from this script,...
        if (anyLogWarnings)
        {
            //return
            return;
        }

        //update coinText with currencyCount
        coinText.text = "Coins: " + PlayerStats.currencyCount.ToString();

        //update shellText with currencyCount
        shellText.text = "Shells: " + PlayerStats.shellCount.ToString();

        //update player health with 
        playerHealthText.text = "Lives: " + PlayerStats.playerHealth.ToString();

        //update upgrade cost texts
        speedUpgradeText.text = PlayerStats.speedUpgradeCost.ToString();
        numberUpgradeText.text = PlayerStats.numberUpgradeCost.ToString();
        attackUpgradeText.text = PlayerStats.attackUpgradeCost.ToString();
        inductionUpgradeText.text = PlayerStats.inductionUpgradeCost.ToString();
        loveUpgradeText.text = PlayerStats.loveUpgradeCost.ToString();

        //if user pressed the toggle shop button,...
        if (userInput.ToggleShop)
        {
            ToggleShop();
        }
    }

    private void ToggleShop()
    {
        //if menu is open,...
        if (isMenuOpen)
        {
            //exit the shop
            ExitShop();
        }
        //else shop is NOT open,...
        else
        {
            //open the shop
            OpenShop();
        }
    }

    private void ExitShop()
    {
        //Resume the game
        Resume();

        //if isMenuOpen is active,...
        if (isMenuOpen)
        {
            //make all menus NOT active
            shopUI.SetActive(false);
            cosmeticsMenuUI.SetActive(false);
            premiumShopUI.SetActive(false);

            //make closedShopUI active
            closedShopUI.SetActive(true);

            //set isMenuOpen to false
            isMenuOpen = false;
        }
        //else isMenuOpen is NOT active,...
        else
        {
            //do nothing
            return;
        }
    }

    private void OpenShop()
    {
        //pause the game
        Pause();

        //if isMenuOpen is active,...
        if (isMenuOpen)
        {
            //do nothing
            return;
        }
        //else isMenuOpen is NOT active,...
        else
        {
            //make shopUI active
            shopUI.SetActive(true);

            //make closedShopUI NOT active
            closedShopUI.SetActive(false);

            //set isMenuOpen to true
            isMenuOpen = true;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    public void ToCosmetics()
    {
        //if isMenuOpen is active,...
        if (isMenuOpen)
        {
            //close shop
            shopUI.SetActive(false);

            //open cosmetics
            cosmeticsMenuUI.SetActive(true);
        }
    }

    public void ToPremium()
    {
        //if isMenuOpen is active,...
        if (isMenuOpen)
        {
            //close shop
            shopUI.SetActive(false);

            //open premium shop
            premiumShopUI.SetActive(true);
        }
    }

    public void ToShop()
    {
        //if isMenuOpen is active,...
        if (isMenuOpen)
        {
            //close cosmetics
            cosmeticsMenuUI.SetActive(false);

            //close premium shop
            premiumShopUI.SetActive(false);

            //open shop
            shopUI.SetActive(true);
        }
    }
}
