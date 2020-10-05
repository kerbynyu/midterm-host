using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    //int elapsedFrames = 0;

   public float speed;
    /* public Vector3 pos1;
     public Vector3 pos2;
    */
    public Transform pos1, pos2; 
    public Transform startPos;
    Vector3 nextPos;


    void Start() {
        nextPos = pos1.position;

    }

    private void FixedUpdate() {
      /*
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        transform.position = Vector3.Lerp(pos1, pos2, interpolationRatio);

        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
      */

        if(transform.position == pos1.position) {
            nextPos = pos2.position;

        }
        if(transform.position == pos2.position){
            nextPos = pos1.position; 
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime); 
    }

    

    private void OnDrawGizmos() {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
