using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public CameraSmoothing mainCamera;

    private Transform currentCheckpoint;
    private Transform checkpoints;

    private Transform currentCameraPoint;
    private Transform cameraPoints;
    
    void Start() {
        checkpoints = GameObject.Find("Checkpoints").transform;
        cameraPoints = GameObject.Find("CameraPoints").transform;

        currentCheckpoint = checkpoints.GetChild(0);
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<CameraSmoothing>();
    }

    void Update() {
        //NOTHING
    }

    public void setCheckpoint(int newCheckpoint) { //update the checkpoint that players respawn at
        currentCheckpoint = checkpoints.GetChild(newCheckpoint);
        currentCameraPoint = cameraPoints.GetChild(newCheckpoint);
        mainCamera.target = currentCameraPoint.transform; //set the camera to its target position, which it will smoothly move toward
    }

    public void resetPlayer(GameObject player) {
        player.transform.position = currentCheckpoint.position;
    }
}
