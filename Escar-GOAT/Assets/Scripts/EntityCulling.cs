using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCulling : MonoBehaviour
{
    [SerializeField] private float cullingDistance = 50.0f;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        //get player transform
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if the distance between the entity and the player is greater than cullingDistance,...
        if(Vector3.Distance(playerTransform.position, gameObject.transform.position) >= cullingDistance)
        {
            //cull the entity
            Destroy(this.gameObject);
        }
    }
}
