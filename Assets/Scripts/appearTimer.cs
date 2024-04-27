using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class appearTimer : MonoBehaviour {
    public float interval = 3; //how often the timer resets
    public AudioPlayer audioPlayer;

    private float timer;
    private bool flipped;
    private TextMeshPro text;
    private List<GameObject> children = new List<GameObject>();

    void Start() {
        timer = interval;
        text = gameObject.GetComponent<TextMeshPro>();
        audioPlayer = new AudioPlayer(transform);
        foreach (Transform child in transform) {
            if(child.gameObject.GetComponent<MeshRenderer>() && child.gameObject.GetComponent<BoxCollider>()) {
                children.Add(child.gameObject);
            }
        }
    }

    void Update() {
        timer -= Time.deltaTime;
        if(timer <= 0) {
            foreach(GameObject child in children) { //either enables or disables each child with both a collider and mesh
                child.GetComponent<MeshRenderer>().enabled = flipped;
                child.GetComponent<BoxCollider>().enabled = flipped;
            }
            timer = interval;
            flipped = !flipped;
            audioPlayer.PlaySound("SwitchSound");
        } else {
            text.text = timer.ToString("f2"); //truncates the timer float to two decimal points
        }
    }
}
