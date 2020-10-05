using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba : MonoBehaviour
{

    public float roombaDetectionDistance = 2f;
    public float roombaSpeed = 4f;


    void Update(){
        Ray2D roombaRay = new Ray2D(transform.position, transform.up);
        Debug.DrawRay(roombaRay.origin, roombaRay.direction * roombaDetectionDistance, Color.white);

        if(Physics2D.Raycast(roombaRay.origin, roombaRay.direction, roombaDetectionDistance)) {

            int randomNumber = Random.Range(0, 100);
            if(randomNumber < 50) {
                transform.Rotate(new Vector3(0,0,90));

            }
            if(randomNumber > 50) {
                transform.Rotate(new Vector3(0,0,-90));
            }

        }else {
            transform.Translate(0, Time.deltaTime * roombaSpeed, 0);

        }
    }
}
