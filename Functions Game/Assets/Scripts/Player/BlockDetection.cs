using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetection : MonoBehaviour
{
    public TextToggle textToggle;

    // Accessing Player Controller Script
    public PlayerActions playerActions;

    // Accessing Player Inventory Script
    public PlayerInventory playerInventory;
    public PressurePlateActiveCheck currentPressurePlate;

    // Private colliders to set the tag of what you just walked into
    public Collider nearbyBlock;
    public Collider nearbySwitch;

    // Private String variables to hold the tag names
    string dtString = "DT_String";
    string dtBool = "DT_Bool";
    string dtInt = "DT_Int";
    string dtFloat = "DT_Float";
    string ppString = "PP_String";
    string ppBool = "PP_Bool";
    string ppInt = "PP_Int";
    string ppFloat = "PP_Float";

    void Awake() {
        textToggle = GameObject.Find("InteractText").GetComponent<TextToggle>();
        playerActions = GetComponentInParent<PlayerActions>();
    }

    // Happens every frame
    private void Update()
    {
        // As long as there is a nearbyBlock...
        if (nearbyBlock != null)
        {
            // Run the TagCheck function
            TagCheck(nearbyBlock);
        }

        if (nearbySwitch != null)
        {
            PressurePlateCheck(nearbySwitch);
        }
    }

    // Only happens when the object enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == dtString || other.tag == dtBool || other.tag == dtFloat || other.tag == dtInt)
        {
            playerActions.canInteract = true;
            nearbyBlock = other;
            Debug.Log("Can I interact? " + playerActions.canInteract);
        }

        if (other.tag == ppString || other.tag == ppBool || other.tag == ppFloat || other.tag == ppInt)
        {
            playerActions.canInteract = true;
            currentPressurePlate = other.GetComponent<PressurePlateActiveCheck>();
            nearbySwitch = other;
            Debug.Log(nearbySwitch.tag);
        }

        if(other.tag == "Interactable") {
            textToggle.showText();
        }
    }

    // Only happens when the object exits the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == dtString || other.tag == dtBool || other.tag == dtFloat || other.tag == dtInt)
        {
            playerActions.canInteract = false;
            nearbyBlock = null;
            Debug.Log("Can I interact? " + playerActions.canInteract);
        }

        if (other.tag == ppString || other.tag == ppBool || other.tag == ppFloat || other.tag == ppInt)
        {
            currentPressurePlate = null;
            playerActions.canInteract = false;
            nearbySwitch = null;
        }

        if(other.tag == "Interactable") {
            textToggle.hideText();
        }
    }

    // Function that takes in a Collider named col then...
    private void TagCheck(Collider col)
    {
        // Runs through if/else checks to match the tag with the string, then do the appropriate action
        if (col.tag == dtString)
        {
            if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F))
            {
                playerInventory.hasStringBlock = true;
                Debug.Log("I just picked up the " + col.tag + " block! " + playerInventory.hasStringBlock);
                Destroy(col.gameObject);
            }

        }
        else if (col.tag == dtBool)
        {
            if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F))
            {
                playerInventory.hasBoolBlock = true;
                Debug.Log("I just picked up the " + col.tag + " block! " + playerInventory.hasBoolBlock);
                Destroy(col.gameObject);
            }
        }
        else if (col.tag == dtInt)
        {
            if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F))
            {
                playerInventory.hasIntBlock = true;
                Debug.Log("I just picked up the " + col.tag + " block! " + playerInventory.hasIntBlock);
                Destroy(col.gameObject);
            }
        }
        else if (col.tag == dtFloat)
        {
            if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F))
            {
                playerInventory.hasFloatBlock = true;
                Debug.Log("I just picked up the " + col.tag + " block! " + playerInventory.hasFloatBlock);
                Destroy(col.gameObject);
            }
        }
    }

    private void PressurePlateCheck(Collider col)
    {
        if (col.tag == ppString)
        {
            // If the character has the correct block & the plate is not active yet
            if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && playerInventory.hasStringBlock == true && currentPressurePlate.isActive == false)
            {
                currentPressurePlate.isActive = true;
                playerInventory.hasStringBlock = false;
                col.transform.Find("Block").gameObject.SetActive(true);
                Debug.Log("You placed the " + col.tag + " block!");
            }
            // If the character tries to put a block on an already active switch
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && currentPressurePlate.isActive == true)
            {
                Debug.Log("This switch is already activated");
            }
            // If the character has the wrong blocks and tries to add it to this one
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && (playerInventory.hasBoolBlock == true || playerInventory.hasFloatBlock == true || playerInventory.hasIntBlock == true))
            {
                Debug.Log("You have the wrong block, try putting that elsewhere.");
            }
            // If the character doesn't have the block
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && playerInventory.hasStringBlock == false)
            {
                Debug.Log("You don't have this block! Go grab it.");
            }
        }
        else if (col.tag == ppBool)
        {
            // If the character has the correct block & the plate is not active yet
            if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && playerInventory.hasBoolBlock == true && currentPressurePlate.isActive == false)
            {
                currentPressurePlate.isActive = true;
                playerInventory.hasBoolBlock = false;
                col.transform.Find("Block").gameObject.SetActive(true);
                Debug.Log("You placed the " + col.tag + " block!");
            }
            // If the character tries to put a block on an already active switch
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && currentPressurePlate.isActive == true)
            {
                Debug.Log("This switch is already activated");
            }
            // If the character has the wrong blocks and tries to add it to this one
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && (playerInventory.hasStringBlock == true || playerInventory.hasFloatBlock == true || playerInventory.hasIntBlock == true))
            {
                Debug.Log("You have the wrong block, try putting that elsewhere.");
            }
            // If the character doesn't have the block
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && playerInventory.hasBoolBlock == false)
            {
                Debug.Log("You don't have this block! Go grab it.");
            }
        }
        else if (col.tag == ppFloat)
        {
            // If the character has the correct block & the plate is not active yet
            if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && playerInventory.hasFloatBlock == true && currentPressurePlate.isActive == false)
            {
                currentPressurePlate.isActive = true;
                playerInventory.hasFloatBlock = false;
                col.transform.Find("Block").gameObject.SetActive(true);
                Debug.Log("You placed the " + col.tag + " block!");
            }
            // If the character tries to put a block on an already active switch
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && currentPressurePlate.isActive == true)
            {
                Debug.Log("This switch is already activated");
            }
            // If the character has the wrong blocks and tries to add it to this one
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && (playerInventory.hasBoolBlock == true || playerInventory.hasStringBlock == true || playerInventory.hasIntBlock == true))
            {
                Debug.Log("You have the wrong block, try putting that elsewhere.");
            }
            // If the character doesn't have the block
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && playerInventory.hasFloatBlock == false)
            {
                Debug.Log("You don't have this block! Go grab it.");
            }
        }
        else if (col.tag == ppInt)
        {
            // If the character has the correct block & the plate is not active yet
            if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && playerInventory.hasIntBlock == true && currentPressurePlate.isActive == false)
            {
                currentPressurePlate.isActive = true;
                playerInventory.hasIntBlock = false;
                col.transform.Find("Block").gameObject.SetActive(true);
                Debug.Log("You placed the " + col.tag + " block!");
            }
            // If the character tries to put a block on an already active switch
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && currentPressurePlate.isActive == true)
            {
                Debug.Log("This switch is already activated");
            }
            // If the character has the wrong blocks and tries to add it to this one
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && (playerInventory.hasBoolBlock == true || playerInventory.hasFloatBlock == true || playerInventory.hasStringBlock == true))
            {
                Debug.Log("You have the wrong block, try putting that elsewhere.");
            }
            // If the character doesn't have the block
            else if (playerActions.canInteract == true && Input.GetKeyDown(KeyCode.F) && playerInventory.hasIntBlock == false)
            {
                Debug.Log("You don't have this block! Go grab it.");
            }
        }
    }
}
