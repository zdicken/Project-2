using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour {
    public GameObject launchDirection;
    public float speed = 15f;

    void OnTriggerEnter(Collider other) { 
        if(other.name.Contains("Player")) { //check if player
            other.GetComponent<PlayerController>().ragdoll(3); //ragdoll player for three seconds
            other.GetComponent<Rigidbody>().AddForce(launchDirection.transform.forward * speed, ForceMode.Impulse); //send player
        }
    }
}
