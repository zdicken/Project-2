using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public GameObject prefab;
    public Transform spawnpoint;
    public float interval = 3;
    public float speed = 50;
    public float variance = 0.5f;

    private float shootTimer;

    void Start() {
        shootTimer = interval;
    }

    void Update() {
        shootTimer -= Time.deltaTime;
        if(shootTimer <= 0) { //replace with object pool if time available
            shootTimer = interval + Random.Range(-variance, variance); //add plus or minus the variance to the time till next shot
            GameObject bullet = Instantiate(prefab, new Vector3(spawnpoint.position.x, spawnpoint.position.y, spawnpoint.position.z), Quaternion.identity); //spawn a new bullet at the child spawnpoint
            bullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * speed; //then set it's velocity to the speed times where the spawnpoint is facing
        }
    }
}
