using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour{

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float speed;

    [SerializeField]
    Transform castPoint;

    bool isFacingLeft;
    Rigidbody2D rb2d;

    private bool isAgro;
    private bool isSearching;


    Animator anim;

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }


    void Update() {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (CanSeePlayer(agroRange)) {
            isAgro = true; 

        }else {
            if(isAgro == true) {
                if (isSearching) {
                    isSearching = true;
                    Invoke("StopChasingPlayer", 5);

                }
            }

        }
        if (isAgro) {
            ChasePlayer();
        }
    }


    void ChasePlayer() {
        if (anim.gameObject.activeSelf) {
            anim.SetTrigger("Walking");
        }

        if (transform.position.x < player.position.x) {
            rb2d.velocity = new Vector2(speed, 0);
            transform.rotation = Quaternion.Euler(0, 180f, 0);

            isFacingLeft = false;

        } else {
            rb2d.velocity = new Vector2(-speed, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFacingLeft = true;
        }
    }


    void StopChasingPlayer(){
        isAgro = false;
        isSearching = false; 
        rb2d.velocity = new Vector2(0, 0);
        anim.SetTrigger("Idle");

    }


    bool CanSeePlayer(float distance) {
        anim.SetTrigger("Idle");
        bool val = false;
        float castDist = distance;

        if (isFacingLeft) {
            castDist = -distance; 
        }

        Vector2 endPos = castPoint.position + Vector3.right * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos,1 << LayerMask.NameToLayer("Action"));

        if(hit.collider!= null) {
            if (hit.collider.gameObject.CompareTag("Player")) {
                val = true;

            }else {
                val = false; 
            }
            Debug.DrawLine(castPoint.position, hit.point, Color.red);
        } else {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);

        }
        return val; 
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            //Hurt();
        }
    }

    public void Hurt() {
        Destroy(this.gameObject);
    }
}
