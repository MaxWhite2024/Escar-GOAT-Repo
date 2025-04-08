using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBehavior : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private UserInput userInput;
    [SerializeField] private HighscoreObject highScore;

    [Header("UI Variables")]
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI shellText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    private bool isShopMenuOpen = false;
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject cosmeticsMenuUI;
    [SerializeField] private GameObject premiumShopUI;
    [SerializeField] private GameObject closedShopUI;
    [SerializeField] private GameObject pauseMenuUI;
    private bool isPauseMenuOpen = false;

    [Header("Upgrade Text Variables")]
    [SerializeField] private TextMeshProUGUI sizeUpgradeText;
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

        //if scoreText has NOT been assigned,...
        if (!scoreText)
        {
            //Log a warning
            Debug.LogWarning("Score Text has not been assigned to Canvas | Please assign a TextMeshProUGUI component to the Shell Text variable");

            //make anyLogWarnings true
            anyLogWarnings = true;
        }

        //if scoreText has NOT been assigned,...
        if (!highscoreText)
        {
            //Log a warning
            Debug.LogWarning("Highscore Text has not been assigned to Canvas | Please assign a TextMeshProUGUI component to the Shell Text variable");

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

        //update scoreText with currencyCount
        scoreText.text = "Score: " + PlayerStats.ScoreCount.ToString();

        //update highscoreText with currencyCount
        highscoreText.text = "Highscore: " + highScore.highscore.ToString();

        //update player health with 
        playerHealthText.text = "Lives: " + PlayerStats.PlayerHealth.ToString();

        //update upgrade cost texts
        sizeUpgradeText.text = PlayerStats.sizeUpgradeCost.ToString();
        numberUpgradeText.text = PlayerStats.numberUpgradeCost.ToString();
        attackUpgradeText.text = PlayerStats.attackUpgradeCost.ToString();
        inductionUpgradeText.text = PlayerStats.inductionUpgradeCost.ToString();
        loveUpgradeText.text = PlayerStats.loveUpgradeCost.ToString();

        //if user pressed the toggle shop button and pause menu is NOT open,...
        if (userInput.ToggleShop && !isPauseMenuOpen)
        {
            ToggleShop();
        }

        //if user pressed the toggle pause button and shop menu is NOT open,...
        if(userInput.TogglePause)
        {
            TogglePauseMenu();
        }
    }

    private void ToggleShop()
    {
        //if menu is open,...
        if (isShopMenuOpen)
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

        //if isShopMenuOpen is active,...
        if (isShopMenuOpen)
        {
            //make all menus NOT active
            shopUI.SetActive(false);
            cosmeticsMenuUI.SetActive(false);
            premiumShopUI.SetActive(false);

            //make closedShopUI active
            closedShopUI.SetActive(true);

            //set isShopMenuOpen to false
            isShopMenuOpen = false;
        }
        //else isShopMenuOpen is NOT active,...
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

        //if isShopMenuOpen is active,...
        if (isShopMenuOpen)
        {
            //do nothing
            return;
        }
        //else isShopMenuOpen is NOT active,...
        else
        {
            //make shopUI active
            shopUI.SetActive(true);

            //make closedShopUI NOT active
            closedShopUI.SetActive(false);

            //set isShopMenuOpen to true
            isShopMenuOpen = true;
        }
    }

    public void TogglePauseMenu()
    {
        //if pause menu is open,...
        if (isPauseMenuOpen)
        {
            //exit the pause menu
            ExitPauseMenu();
        }
        //else shop is NOT open,...
        else
        {
            //open the shop
            EnterPauseMenu();
        }
    }

    private void ExitPauseMenu()
    {
        if(!isShopMenuOpen)
            Resume();

        //if isPauseMenuOpen is active,...
        if (isPauseMenuOpen)
        {
            //make pause menus inactive
            pauseMenuUI.SetActive(false);

            //set isShopMenuOpen to false
            isPauseMenuOpen = false;
        }
        //else isPauseMenuOpen is NOT active,...
        else
        {
            //do nothing
            return;
        }
    }

    private void EnterPauseMenu()
    {
        Pause();

        //if isPauseMenuOpen is active,...
        if (isPauseMenuOpen)
        {
            //do nothing
            return;
        }
        //else isPauseMenuOpen is NOT active,...
        else
        {
            //make shopUI active
            pauseMenuUI.SetActive(true);

            //set isPauseMenuOpen to true
            isPauseMenuOpen = true;
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
        //if isShopMenuOpen is active,...
        if (isShopMenuOpen)
        {
            //close shop
            shopUI.SetActive(false);

            //open cosmetics
            cosmeticsMenuUI.SetActive(true);
        }
    }

    public void ToPremium()
    {
        //if isShopMenuOpen is active,...
        if (isShopMenuOpen)
        {
            //close shop
            shopUI.SetActive(false);

            //open premium shop
            premiumShopUI.SetActive(true);
        }
    }

    public void ToShop()
    {
        //if isShopMenuOpen is active,...
        if (isShopMenuOpen)
        {
            //close cosmetics
            cosmeticsMenuUI.SetActive(false);

            //close premium shop
            premiumShopUI.SetActive(false);

            //open shop
            shopUI.SetActive(true);
        }
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("Start");
    }
}
