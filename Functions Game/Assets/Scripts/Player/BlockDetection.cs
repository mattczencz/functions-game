using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetection : MonoBehaviour
{
    // Accessing Player Controller Script
    public CharacterController charCont;

    // Accessing Player Inventory Script
    public PlayerInventory playerInventory;

    // Private collider to set the tag of what you just walked into
    public Collider nearbyBlock;

    // Private String variables to hold the tag names
    string dtString = "DT_String";
    string dtBool = "DT_Bool";
    string dtInt = "DT_Int";
    string dtFloat = "DT_Float";

    // Happens every frame
    private void Update()
    {
        // As long as there is a nearbyBlock...
        if (nearbyBlock != null)
        {
            // Run the TagCheck function
            TagCheck(nearbyBlock);
        }
    }

    // Only happens when the object enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == dtString || other.tag == dtBool || other.tag == dtFloat || other.tag == dtInt)
        {
            charCont.canInteract = true;
            nearbyBlock = other;
            Debug.Log("Can I interact? " + charCont.canInteract);
        }
    }

    // Only happens when the object exits the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == dtString || other.tag == dtBool || other.tag == dtFloat || other.tag == dtInt)
        {
            charCont.canInteract = false;
            nearbyBlock = null;
            Debug.Log("Can I interact? " + charCont.canInteract);
        }
    }

    // Function that takes in a Collider named col then...
    private void TagCheck(Collider col)
    {
        // Runs through if/else checks to match the tag with the string, then do the appropriate action
        if (col.tag == dtString)
        {
            if (charCont.canInteract == true && Input.GetKeyDown(KeyCode.F))
            {
                playerInventory.hasStringBlock = true;
                Debug.Log("I just picked up the " + col.tag + " block! " + playerInventory.hasStringBlock);
                Destroy(col.gameObject);
            }

        }
        else if (col.tag == dtBool)
        {
            if (charCont.canInteract == true && Input.GetKeyDown(KeyCode.F))
            {
                playerInventory.hasBoolBlock = true;
                Debug.Log("I just picked up the " + col.tag + " block! " + playerInventory.hasStringBlock);
                Destroy(col.gameObject);
            }
        }
        else if (col.tag == dtInt)
        {
            if (charCont.canInteract == true && Input.GetKeyDown(KeyCode.F))
            {
                playerInventory.hasIntBlock = true;
                Debug.Log("I just picked up the " + col.tag + " block! " + playerInventory.hasStringBlock);
                Destroy(col.gameObject);
            }
        }
        else if (col.tag == dtFloat)
        {
            if (charCont.canInteract == true && Input.GetKeyDown(KeyCode.F))
            {
                playerInventory.hasFloatBlock = true;
                Debug.Log("I just picked up the " + col.tag + " block! " + playerInventory.hasStringBlock);
                Destroy(col.gameObject);
            }
        }
    }
}
