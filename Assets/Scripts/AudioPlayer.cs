using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
    //perhaps use arraylist ?

    void Start() {
        
    }

    public void PlaySound(string name) { //gets the child with the given name and plays its sound
        AudioSource audio = transform.Find(name).GetComponent<AudioSource>();
        print(audio);
        if(audio) { //null test
            audio.Play();
        }
    }
}
