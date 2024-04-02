using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerObject : MonoBehaviour {
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
