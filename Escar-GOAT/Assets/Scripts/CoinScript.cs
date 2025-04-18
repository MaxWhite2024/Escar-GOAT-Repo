using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float coinSpeed;
    public float coinAcceleration; // Acceleration speed of the coin
    public float accelerationPower; // Increase the accelration curve
    public float maxVelocity;
    public float coinDespawnTime;
    private float _coinSpeed;
    [HideInInspector] public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Despawn the coin after a certain amount of time.
        Destroy(gameObject, coinDespawnTime);

        if (player == null)
            player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CoinAccelerate();
    }

    void CoinAccelerate()
    {
        // Check if the coin is close enough to the player
        float dist = Vector3.Distance(player.transform.position, transform.position);
        
        float _coinAcceleration;
        
        // Gradually increases the acceleration, thus exponentially increasing the coin velocity
        _coinAcceleration = (coinAcceleration / dist) * accelerationPower;

        // Exponentially increase the coin velocity but ensure that it doesn't go above the speed limit
        if (_coinSpeed < maxVelocity)
            _coinSpeed = (coinSpeed / dist) * Mathf.Pow(_coinAcceleration, accelerationPower);

        // If coin is close enough to the player, move towards the player
        if (dist <= PlayerStats.coinPickupRange) 
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _coinSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
