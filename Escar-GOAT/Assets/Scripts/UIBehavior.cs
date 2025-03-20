using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBehavior : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TextMeshProUGUI coinText;

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
    }
}
