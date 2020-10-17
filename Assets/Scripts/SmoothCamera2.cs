using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera2 : MonoBehaviour {//add to main camera

    public Transform target;
    public float smoothTime = 0.3f;

    Vector3 thisVelocty = Vector3.zero;
    public bool inDeadZone;
    public bool inCamera; 

    private static SmoothCamera2 instance;

    public float maxTime;
    public float currentTime;
    public bool playerDead = false;
    private GameMaster gm;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameMaster>();
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.V)) {
            FindPlayer();
        }

        if (instance != null) {
            if (inDeadZone == true) {
                currentTime = maxTime;
            }

            if (inDeadZone == false) {
                if (currentTime <= 0) {
                    return;
                }

                currentTime -= Time.deltaTime;
            }

            if (target != null) {
                Vector3 targetPosition = target.TransformPoint(new Vector3(0, 3, -10f));
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref thisVelocty, smoothTime);

            }
            
            if(target == null) {
                FindPlayer();
            }
        }
    }

    public void FindPlayer() {
        GameObject searchResult = GameObject.FindGameObjectWithTag("Player");

        if (searchResult != null) {
            target = searchResult.transform;
            Vector3 targetPosition = target.TransformPoint(searchResult.transform.position);
            // transform.position = Vector3.SmoothDamp(gm.lastCheckPointPos, targetPosition, ref thisVelocty, smoothTime);
            transform.position = Vector3.SmoothDamp(target.position, targetPosition, ref thisVelocty, smoothTime);

        }
    }


    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);

        }
        else {
            Destroy(gameObject);

        }
    }
}