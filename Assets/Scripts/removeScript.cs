using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeScript : MonoBehaviour {
    public AudioPlayer audioPlayer;
    public string soundToPlay;

    private List<triggerObject> triggers = new List<triggerObject>();
    
    void Start() {
        audioPlayer = new AudioPlayer(transform);
        foreach (Transform child in transform) { //find each child gameobject with the triggerObject script and add them to the triggers array
            triggerObject newTrigger = child.gameObject.GetComponent<triggerObject>();
            if(newTrigger) { //null test for the script
                triggers.Add(newTrigger);
            }
        }
    }

    void FixedUpdate() {
        foreach(triggerObject trigger in triggers) { //read each part of the trigger array
            if(!trigger.getIsTriggered()) {
                return; //if any of the triggers aren't active, break out of the update
            }
        }
        audioPlayer.PlaySound(soundToPlay);
        Destroy(this.gameObject); //otherwise, remove this gameobject (and by extension its children)
    }
}
