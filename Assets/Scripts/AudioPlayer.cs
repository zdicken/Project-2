using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer {
    private Transform transform;

    public AudioPlayer(Transform t) { transform = t; } //gets and stores the parent's transform

    public void PlaySound(string name) { //gets the child with the given name and plays its sound
        AudioSource audio = transform.Find(name).GetComponent<AudioSource>();
        if(audio) { //null test
            audio.Play();
        }
    }
}
