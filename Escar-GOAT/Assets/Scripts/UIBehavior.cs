using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBehavior : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private UserInput userInput;

    [Header("UI Variables")]
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject shopMenu;

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
        coinText.text = "Coins: " + playerController.currencyCount.ToString();

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    if (shopMenu.activeSelf)
        //        ExitShop();
        //    else
        //        OpenShop();
        //}
        if(userInput.ToggleShop)
        {
            if (shopMenu.activeSelf)
                ExitShop();
            else
                OpenShop();
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

    private void FixedUpdate()
    {
        //if(Input.GetKeyDown(KeyCode.E))
        //{
        //    Debug.Log("Here");
        //    if (shopMenu.activeSelf)
        //        ExitShop();
        //    else
        //        OpenShop();
        //}
        ////userInput.; ???
        ////when player presses down
        ////move selection down

        ////when player presses up
        ////move selection up

        ////when player presses select
        ////select the current UI item

        ////when player deselects 
        ////exit shop
        //ExitShop();
    }

    private void ExitShop()
    {
        //if shopMenu is active,...
        if (shopMenu.activeSelf)
        {
            //make shopMenu NOT active
            shopMenu.SetActive(false);
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
        if(shopMenu.activeSelf)
        {
            //do nothing
            return;
        }
        //else shopMenu is NOT active,...
        else
        {
            //make shopMenu active
            shopMenu.SetActive(true);
        }
    }
}
