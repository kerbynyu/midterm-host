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

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
            //StopChasingPlayer();

        }
        if (isAgro) {
            ChasePlayer();
        }
    }

    void ChasePlayer() {
        if(transform.position.x < player.position.x) {
            rb2d.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(1, 1);

            isFacingLeft = false;

        } else {
            rb2d.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);

            isFacingLeft = true;
        }
    }

    void StopChasingPlayer(){
        isAgro = false;
        isSearching = false; 
        rb2d.velocity = new Vector2(0, 0);

    }

    bool CanSeePlayer(float distance) {
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
            Debug.DrawLine(castPoint.position, hit.point, Color.blue);
        } else {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);

        }
        return val; 
    }
}
