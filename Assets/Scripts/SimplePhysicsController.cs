using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePhysicsController : MonoBehaviour
{

    public SpriteRenderer thisSprite;
    public Rigidbody2D thisRigidbody2D;
    public float force = 10f;
    public float jumpforce = 10;
    public bool onplatform;
    public float gravityInAir;
    public int score = 0; 
    public float gravityScale;
    public Vector3 movementVector;
    public bool doubleJump = false;
    


    void Start(){
        GetComponent<Rigidbody2D>();
       
    }


    void FixedUpdate(){
        //move left with 'a'
        if (Input.GetKey(KeyCode.A)){
            this.thisRigidbody2D.AddForce(-Vector2.right * force * Time.deltaTime, ForceMode2D.Impulse);

            if(thisSprite.flipX == true){
                thisSprite.flipX = false; 
            }
        }

        //move right with 'd' 
        if (Input.GetKey(KeyCode.D)){
            this.thisRigidbody2D.AddForce(Vector2.right * force * Time.deltaTime, ForceMode2D.Impulse);

            if (thisSprite.flipX == false){
                thisSprite.flipX = true;
            }
        }
    }


    private void Update(){
        //jump up with 'space' 
        if (Input.GetKeyDown(KeyCode.Space)) {
            doubleJump = true;

            this.thisRigidbody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            thisRigidbody2D.gravityScale = gravityScale;

            if (GameObject.Find("GroundDetection").GetComponent<GroundCheck2>().isGrounded == true) {
                thisRigidbody2D.gravityScale = 1;

                //DOUBLE jump 
                if (doubleJump == true) {
                    doubleJump = false;
                    thisRigidbody2D.gravityScale = 0;
                    this.thisRigidbody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

                }

            //falling    
            } else {
                thisRigidbody2D.gravityScale = gravityInAir;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Points")) {
            score++; 

        }
    }

}

