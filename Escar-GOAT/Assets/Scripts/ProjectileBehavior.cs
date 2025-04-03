using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    //[HideInInspector] 
    public Vector2 direction = Vector2.zero;
    [SerializeField] private float projectileSpeed = 1000f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float lifeTime = 8f;

    private void Start()
    {
        //destroy self after "lifeTime" seconds
        Destroy(gameObject, lifeTime);

        //apply a force to self in the specified diretion at projectileSpeed
        rb.AddForce(direction.normalized * projectileSpeed, ForceMode2D.Impulse);
    }
}
