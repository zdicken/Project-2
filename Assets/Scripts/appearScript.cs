using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appearScript : MonoBehaviour {
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
            if (!trigger.getIsTriggered()) { //if any child trigger objects aren't triggered, disable the mesh and collider and break out of the fixedupdate()
                setEnabled(false);
                return;
            }
        }
        setEnabled(true);
    }

    private void setEnabled(bool newStatus) { //gets provided components and disables/enables it
        mesh.enabled = newStatus;
        boxCollider.enabled = newStatus;
    }
}
