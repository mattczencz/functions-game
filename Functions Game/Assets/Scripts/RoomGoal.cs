using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGoal : MonoBehaviour
{
    public PressurePlateActiveCheck[] activeCheck;
    private Transform blocker;
    private Animator blockerAnim;

    void Awake() {
        activeCheck = GetComponentsInChildren<PressurePlateActiveCheck>();
        blocker = gameObject.transform.Find("Blocker");
        blockerAnim = blocker.GetComponent<Animator>();
    }

    void Update() {
        if(IsRoomComplete()) {
            blockerAnim.SetBool("roomCompleted", true);
        }
    }

    private bool IsRoomComplete() {
        // Loop through each of the Components in the list
        foreach(PressurePlateActiveCheck item in activeCheck){
            // If any of the are not active (meaning room is not complete)
            if(item.isActive == false){
                // Return false
                return false;
            }
        }
        // Otherwise, return true (room is complete, all are active)
        return true;
    }
}
