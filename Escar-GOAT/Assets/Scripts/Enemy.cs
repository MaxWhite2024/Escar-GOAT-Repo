using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Vars")]
    [SerializeField] private float speed;

    [Header("References")]
    public EnemyManager manager;
    [SerializeField] private GameObject coinPrefab;

    private GameObject player;
    private Vector3 playerPos;
    private Rigidbody2D rb;
    private Damageable enemyHealth;
    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (enemyHealth == null) 
            enemyHealth = GetComponent<Damageable>();

        maxHealth = enemyHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        playerPos = player.transform.position;

        Vector3 distance = (playerPos - transform.position);
        rb.velocity = (distance.normalized * speed);
    }

    public void Die()
    {
        Instantiate(coinPrefab, this.transform.position, this.transform.rotation);
        PlayerStats.scoreCount += maxHealth;
        //manager.enemies.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

}
