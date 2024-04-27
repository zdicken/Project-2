using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class winScript : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        EditorUtility.DisplayDialog("Congratulations!", "You're Winner!", "OK");
        Destroy(this.gameObject);
    }
}
