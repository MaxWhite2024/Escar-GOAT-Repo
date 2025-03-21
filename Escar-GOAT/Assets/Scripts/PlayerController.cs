using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector] public UserInput input; // Include the input system
    [HideInInspector] public Vector2 axis;

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
