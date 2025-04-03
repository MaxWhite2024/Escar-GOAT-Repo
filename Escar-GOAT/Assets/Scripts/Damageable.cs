using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DamageableType { Player, Enemy};

public class Damageable : MonoBehaviour
{

    public int health;
    [SerializeField] private DamageableType type;

    private void Awake()
    {
        //if this damageableType is the player,...
        if (type == DamageableType.Player)
        {
            //set PlayerStats to equal health
            health = PlayerStats.playerHealth;
        }
    }

    private void Update()
    {
        if (type == DamageableType.Player) 
        { 
            health = PlayerStats.playerHealth;
        }
    }

    private void CollisionLogic(Collider2D collision)
    {

        if(collision.gameObject.layer == this.gameObject.layer)
        {
            return;
        }

        DamageSource damage = collision.GetComponent<DamageSource>();
        if (damage == null)
        {
            return;
        }
        
        health -= damage.damage;

        //if this damageableType is the player,...
        if(type == DamageableType.Player)
        {
            //update PlayerStats to equal health
            PlayerStats.playerHealth = health;
        }

        if(health <= 0)
        {
            Death();
        }
        
    }

    private void Death()
    {
        if (type == DamageableType.Player)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            this.gameObject.GetComponent<Enemy>().Die();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionLogic(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionLogic(collision);
    }
}
