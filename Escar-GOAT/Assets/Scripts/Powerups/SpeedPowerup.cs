using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public float despawnTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, despawnTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            // StartCoroutine(other.GetComponent<PlayerController>().TempSpeedUp());
        }
    }
}
