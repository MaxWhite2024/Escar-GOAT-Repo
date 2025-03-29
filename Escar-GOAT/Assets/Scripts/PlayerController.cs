using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public UserInput input; // Include the input system
    [HideInInspector] public Vector2 axis;

    //aiming and shooting vars
    private Vector2 aimDirection;
    [SerializeField] private Transform playerWeaponTransform;
    private float tempFireRate = 0.0f;
    [SerializeField] private GameObject playerBulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private SpriteRenderer playerSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (input == null)
        {
            // Referencing the input system
            input = GameObject.Find("Input Manager").GetComponent<UserInput>();
        }

        PlayerStats.ResetPlayer();
    }


    // Update is called once per frame
    void Update()
    {
        axis = input.MoveInput; // Variable that detects player's movement input

        //update aimDirection based on CursorPosition and player position
        aimDirection = input.MousePos - (Vector2)gameObject.transform.position;

        //swap player x scale based on aimDirection
        if (aimDirection.x >= 0)
        {
            playerSprite.flipX = false;
        }
        else
        {
            playerSprite.flipX = true;
        }

        //rotate player weapon based on aimDirection
        playerWeaponTransform.rotation =
            Quaternion.Euler(new Vector3(0f, 0f, Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg));

        //if fire rate time has elapsed,...
        if (tempFireRate >= (1f / PlayerStats.shotsPerSecond))
        {
            //fire a projectile
            GameObject projectileInstance = Instantiate(playerBulletPrefab, firePoint.position, Quaternion.identity);
            projectileInstance.GetComponent<ProjectileBehavior>().direction = aimDirection;
            projectileInstance.GetComponent<DamageSource>().damage = PlayerStats.projectileDamage;

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
        rb.velocity =
            new Vector2(axis.x * PlayerStats.movementSpeed,
                axis.y * PlayerStats.movementSpeed); // This moves the player
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Increase currency upon touching the coin
        if (other.CompareTag("Coin"))
        {
            PlayerStats.currencyCount++;
            PlayerStats.scoreCount++;
        }
    }
}