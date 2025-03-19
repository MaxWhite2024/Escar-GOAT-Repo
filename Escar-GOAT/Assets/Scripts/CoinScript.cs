using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float collectDistance;
    public float coinSpeed;
    public float coinDespawnTime;
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
        // Check if the coin is close enough to the player
        float dist = Vector3.Distance(player.transform.position, transform.position);

        // If coin is close enough to the player, move towards the player
        if (dist <= collectDistance) 
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, coinSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
