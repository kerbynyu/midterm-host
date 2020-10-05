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
    int jumpcounter =1; 
    public bool doubleJump = false;
    public bool isJumping; 
    


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

        thisRigidbody2D.gravityScale = gravityScale;

        //jump up with 'space' 
        if (Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
            Debug.Log(jumpcounter);

            if (jumpcounter >= 2) {
                jumpcounter = 0;
            }

            if (GameObject.Find("Feet").GetComponent<GroundCheck2>().isGrounded == true) {
                //thisRigidbody2D.gravityScale = 1;

                thisRigidbody2D.gravityScale = 0;
                this.thisRigidbody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

                doubleJump = true;

                

            } else if (Input.GetKeyDown(KeyCode.Space) && doubleJump == true) {
                    thisRigidbody2D.gravityScale = 0;
                    this.thisRigidbody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                    doubleJump = false;

                }
            } else {
                thisRigidbody2D.gravityScale = gravityInAir;

            }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            isJumping = false; 
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Points")) {
            score++; 

        }
    }

}

