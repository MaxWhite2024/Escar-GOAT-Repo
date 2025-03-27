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
    private bool isShopOpen = false;
    [SerializeField] private List<GameObject> openedShopUI;
    [SerializeField] private List<GameObject> closedShopUI;

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
        playerHealthText.text = "Health: " + PlayerStats.playerHealth.ToString();

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
        //if shop is open,...
        if (isShopOpen)
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

        //if shopMenu is active,...
        if (isShopOpen)
        {
            //make all openedShopUI NOT active
            for (int i = 0; i < openedShopUI.Count; i++)
            {
                openedShopUI[i].SetActive(false);
            }

            //make all closedShopUI active
            for (int i = 0; i < closedShopUI.Count; i++)
            {
                closedShopUI[i].SetActive(true);
            }

            //set isShopOpen to false
            isShopOpen = false;
        }
        //else shopMenu is NOT active,...
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

        //if shopMenu is active,...
        if(isShopOpen)
        {
            //do nothing
            return;
        }
        //else shopMenu is NOT active,...
        else
        {
            //make all openedShopUI active
            for (int i = 0; i < openedShopUI.Count; i++)
            {
                openedShopUI[i].SetActive(true);
            }

            //make all closedShopUI NOT active
            for (int i = 0; i < closedShopUI.Count; i++)
            {
                closedShopUI[i].SetActive(false);
            }

            //set isShopOpen to true
            isShopOpen = true;
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
        //close shop

        //open cosmetics
    }

    public void ToPremium()
    {

    }

    public void ToShop()
    {
        
    }
}
