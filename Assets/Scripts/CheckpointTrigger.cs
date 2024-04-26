using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour {
    public int nextCheckpoint = 0;

    private GameController gameController;

    void Start() {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>(); //find game controller
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name.Contains("Player")) { //if a player enters the trigger, remove this object and go to specified checkpoint
            gameController.setCheckpoint(nextCheckpoint);
            Destroy(this);
        }
    }
}
