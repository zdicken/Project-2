using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeScript : MonoBehaviour {
    private triggerObject[] triggers;
    
    void Start() {
        int i = 0;
        triggers = new triggerObject[this.transform.childCount];
        foreach (Transform child in transform) {
            triggers[i] = child.gameObject.GetComponent<triggerObject>();
            i++;
        }
    }

    void FixedUpdate() {
        foreach(triggerObject trigger in triggers) {
            print(trigger.getIsTriggered());
            if(!trigger.getIsTriggered()) {
                return;
            }
        }
        Destroy(this.gameObject);
    }
}
