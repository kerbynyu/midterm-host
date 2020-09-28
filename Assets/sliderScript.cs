using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderScript : MonoBehaviour
{
    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;

    float speed;
    public Vector3 pos;
    public Vector3 pos2;
    public Transform target;

    public float sspeed = 2.0f;


    private void FixedUpdate() {
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        transform.position = Vector3.Lerp(pos, pos2, interpolationRatio);

        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
    }

    void start() {
        





    }
}
