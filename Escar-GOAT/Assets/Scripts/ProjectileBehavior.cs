using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    //[HideInInspector] 
    public Vector2 direction = Vector2.zero;
    [SerializeField] private float projectileSpeed = 1000f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float lifeTime = 10f;

    private void Start()
    {
        //destroy self after "lifeTime" seconds
        Destroy(gameObject, lifeTime);

        //apply a force to self in the specified diretion at projectileSpeed
        rb.AddForce(direction.normalized * projectileSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionLogic(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionLogic(collision);
    }

    //if the projectile comes into contact with something it can touch,...
    private void CollisionLogic(Collider2D collision)
    {
        //destroy self 
        Destroy(gameObject, 0.1f);
    }
}
