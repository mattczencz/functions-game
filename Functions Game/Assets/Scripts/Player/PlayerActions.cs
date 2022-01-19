using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public bool canInteract = false;
    public bool interacting = false;

    void Update() {
        if(interacting == true) {
            Debug.Log("Interacting...");
        }
    }
}
