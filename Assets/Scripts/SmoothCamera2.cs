using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera2 : MonoBehaviour
{//add to main camera

    public Transform target;
    public float smoothTime = 0.3f;

    Vector3 thisVelocty = Vector3.zero;
    public bool inDeadZone;

    public float maxTime;
    public float currentTime; 


 
    void FixedUpdate(){
        if (inDeadZone == true){
            currentTime = maxTime; 
        }

        if(inDeadZone == false){
            if (currentTime <= 0) {
                return;
            }

            currentTime -= Time.deltaTime;
        }

        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 3, -10f));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref thisVelocty, smoothTime);

        
    }
}
