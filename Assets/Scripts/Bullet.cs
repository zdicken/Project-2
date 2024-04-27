using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifetime = 3;
    private float removeTimer;

    void Start() {
        removeTimer = lifetime;
    }

    void Update() { 
        removeTimer -= Time.deltaTime;
        if(removeTimer <= 0) { //remove after the lifetime is finished
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.name.Contains("Player")) { //check if player
            other.GetComponent<PlayerController>().ragdoll(2); //ragdoll player for one second
            other.GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity / 2, ForceMode.Impulse); //this sucks: fix the original issue with the player rigidbody instead
        }
    }
}
