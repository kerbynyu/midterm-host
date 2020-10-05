using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour{


    //RaycastGroundCheck2



    public float maxDistance = 1f;
    SpriteRenderer thisSprite; 
    // Start is called before the first frame update
    void Start() {
        thisSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update(){
        //1. Declare ray in point of origin 
        Ray myRay = new Ray(transform.position, Vector2.down);

        //2. Set max distance

        //3. Draw a line that shows the origin
        Debug.DrawRay(myRay.origin, myRay.direction * maxDistance, Color.red);

        if(Physics2D.Raycast(myRay.origin, myRay.direction, maxDistance)) {
            thisSprite.color = Color.cyan;

        }else {
            thisSprite.color = Color.red;

        }
    }
}
