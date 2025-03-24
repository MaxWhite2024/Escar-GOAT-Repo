using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DamageableType { Player, Enemy};

public class Damageable : MonoBehaviour
{

    public int health;
    [SerializeField] private DamageableType type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CollisionLogic(Collider2D collision)
    {

        DamageSource damage = collision.GetComponent<DamageSource>();
        if (damage == null)
        {
            return;
        }
        
        health -= damage.damage;

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
