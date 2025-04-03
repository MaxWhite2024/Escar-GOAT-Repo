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
    public int maxHealth;
    private SpriteRenderer sprite;
    private bool knockedBack;
    private float knockedBackTimer = .5f;


    // Start is called before the first frame update
    void Awake()
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

        maxHealth = 1;
        enemyHealth.health = maxHealth;
        sprite = GetComponent <SpriteRenderer>();
        knockedBack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (knockedBack && knockedBackTimer > 0)
        {
            knockedBackTimer -= Time.deltaTime;
        }
        else if(knockedBack)
        {
            knockedBack = false;
            knockedBackTimer = .5f;
        }
        else
        {
            MoveToPlayer();
            sprite.flipX = (playerPos.x < transform.position.x);
        }
        
    }

    public void SetHealth(int health)
    {
        maxHealth += health;
        enemyHealth.health += health;
    }

    private void MoveToPlayer()
    {
        playerPos = player.transform.position;

        Vector3 distance = (playerPos - transform.position);
        rb.velocity = (distance.normalized * speed);
    }

    public void KnockBack(float knockbackSpeed)
    {
        knockedBack = true;
        playerPos = player.transform.position;

        Vector3 distance = (transform.position - playerPos);
        rb.velocity = (distance.normalized * knockbackSpeed);
    }

    public void Die()
    {
        Instantiate(coinPrefab, this.transform.position, this.transform.rotation);
        PlayerStats.scoreCount += maxHealth;
        manager.enemies.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

}
