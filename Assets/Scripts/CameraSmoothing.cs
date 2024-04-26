using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothing : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;

    void Start() {
        target = transform; //set target to initial location so it doesn't get confused
    }

    void FixedUpdate() {
        //smoothly move the camera towards target position (usually defined by gameController)
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, smoothTime);
    }
}
