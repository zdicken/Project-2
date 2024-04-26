using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appearScript : MonoBehaviour {
    public bool requiresAll = true; //fix this

    private List<triggerObject> triggers = new List<triggerObject>();
    private MeshRenderer mesh;
    private BoxCollider boxCollider;
    
    void Start() {
        foreach (Transform child in transform) {
            triggers.Add(child.gameObject.GetComponent<triggerObject>());
        }

        mesh = gameObject.GetComponent<MeshRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    void FixedUpdate() {
        foreach(triggerObject trigger in triggers) {
            //print(trigger.getIsTriggered());
            if (!trigger.getIsTriggered() && requiresAll) {
                mesh.enabled = false;
                boxCollider.enabled = false;
                return;
            } else if (trigger.getIsTriggered() && !requiresAll) {
                mesh.enabled = true;
                boxCollider.enabled = true;
                return;
            } else {
                mesh.enabled = false;
                boxCollider.enabled = false;
            }
        }
        mesh.enabled = true;
        boxCollider.enabled = true;
    }
}
