using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundSpriteRenderer;
    [SerializeField] private PlayerController playerController;
    private Vector2 currentPos;
    private Vector2 previousPos;


    // Start is called before the first frame update
    void Start()
    {
        currentPos = previousPos = playerController.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPos = playerController.transform.position;
        
        //Difference between current position and previous physics update position
        Vector2 diff = currentPos - previousPos;    
        
        //Get current UV offset of the material texture
        Vector2 currentOffset = backgroundSpriteRenderer.material.mainTextureOffset;
        
        //Calculate new UV offset value
        Vector2 newOffset = currentOffset + diff * 0.5f; //No idea why but it only works properly if I multiply the difference by 0.5
        
        //Constrain the uv values to be between 0 and 1 only
        newOffset.x %= 1;
        newOffset.y %= 1;
        
        backgroundSpriteRenderer.material.SetTextureOffset("_MainTex", newOffset);
        previousPos = currentPos;
    }
}