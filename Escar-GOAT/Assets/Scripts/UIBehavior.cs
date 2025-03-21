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
            Debug.LogWarning("Coin Text has not been assigned to Canvas | Please assign a TextMeshProUGUI to the Coin Text variable");

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

        //when player presses down
        //move selection down

        //when player presses up
        //move selection up

        //when player presses select
        //select the current UI item

        //when player deselects 
        //exit shop
        //ExitShop();
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
}
