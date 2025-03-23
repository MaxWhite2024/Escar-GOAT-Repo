using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector] public UserInput input; // Include the input system
    [HideInInspector] public Vector2 axis;
    private Vector2 aimDirection;
    [SerializeField] private Transform playerWeaponTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(input == null){ // Referencing the input system
            input = GameObject.Find("Input Manager").GetComponent<UserInput>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        axis = input.MoveInput; // Variable that detects player's movement input

        Debug.Log(input.MousePos);
        //update aimDirection based on CursorPosition and player position
        aimDirection = input.MousePos - (Vector2)gameObject.transform.position;

        //rotate player weapon based on aimDirection
        playerWeaponTransform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg));
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
