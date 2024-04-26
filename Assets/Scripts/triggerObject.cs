using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerObject : MonoBehaviour {
    //self explanatory script. you walk into the trigger, the object is triggered. you walk out of the trigger, it's no longer triggered.
    private bool isTriggered;
    
    void OnTriggerEnter(Collider other) {
        isTriggered = true;
    }

    void OnTriggerExit(Collider other) {
        isTriggered = false;
    }

    public bool getIsTriggered() {
        return isTriggered;
    }
}
