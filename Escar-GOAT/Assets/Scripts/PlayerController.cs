using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector] public UserInput input; // Include the input system
    [HideInInspector] public Vector2 axis;

    //aiming and shooting vars
    private Vector2 aimDirection;
    [SerializeField] private Transform playerWeaponTransform;
    private float tempFireRate = 0.0f;
    [SerializeField] private GameObject playerBulletPrefab;
    [SerializeField] private Transform firePoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(input == null){ // Referencing the input system
            input = GameObject.Find("Input Manager").GetComponent<UserInput>();
        }

        ResetPlayer();
    }

    /// <summary>
    /// Resets the player's stats
    /// </summary>
    private void ResetPlayer()
    {
        PlayerStats.movementSpeed = 1;
        PlayerStats.numberOfProjectilesPerShot = 1;
        PlayerStats.shotsPerSecond = 1;
        PlayerStats.coinPickupRange = 3f;
        PlayerStats.maxHealth = 3;

        PlayerStats.speedUpgradeCost = 1;
        PlayerStats.numberUpgradeCost = 1;
        PlayerStats.attackUpgradeCost = 1;
        PlayerStats.inductionUpgradeCost = 1;
        PlayerStats.loveUpgradeCost = 1;

        PlayerStats.currencyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        axis = input.MoveInput; // Variable that detects player's movement input

        //update aimDirection based on CursorPosition and player position
        aimDirection = input.MousePos - (Vector2)gameObject.transform.position;

        //rotate player weapon based on aimDirection
        playerWeaponTransform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg));

        //if fire rate time has elapsed,...
        if(tempFireRate >= (1f / PlayerStats.shotsPerSecond))
        {
            //fire a projectile
            GameObject projectileInstance = Instantiate(playerBulletPrefab, firePoint.position, Quaternion.identity);
            projectileInstance.GetComponent<ProjectileBehavior>().direction = aimDirection;

            //reset tempFireRate
            tempFireRate = 0f;
        }
        //else fire rate time has NOT elapsed,...
        else
        {
            //increment tempFireRate
            tempFireRate += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(axis.x * PlayerStats.movementSpeed, axis.y * PlayerStats.movementSpeed); // This moves the player
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Increase currency upon touching the coin
        if (other.CompareTag("Coin"))
        {
            PlayerStats.currencyCount++;
        }
    }
}
