using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockDetection : MonoBehaviour
{
    public GameObject blockErrorUI;
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

    void Awake()
    {
        textToggle = GameObject.Find("InteractText").GetComponent<TextToggle>();
        playerActions = GetComponentInParent<PlayerActions>();
        blockErrorUI = GameObject.Find("BlockError");
        blockErrorUI.SetActive(false);
    }

    // Happens every frame
    private void Update()
    {
        // As long as there is a nearbyBlock...
        if (nearbyBlock != null)
        {
            // If the player already has a block
            if (playerInventory.invCount > 0)
            {
                // Put it back
                PutBack(nearbyBlock);
            }

            // Otherwise, if they don't have a block
            else if (playerInventory.invCount < 1)
            {
                // Pick it up
                PickUp(nearbyBlock);
            }
        }

        if (nearbySwitch != null)
        {
            PlaceBlock(nearbySwitch);
        }
    }

    // Only happens when the object enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == dtString || other.tag == dtBool || other.tag == dtFloat || other.tag == dtInt)
        {
            playerActions.canInteract = true;
            nearbyBlock = other;
            textToggle.showText();
        }

        if (other.tag == ppString || other.tag == ppBool || other.tag == ppFloat || other.tag == ppInt)
        {
            playerActions.canInteract = true;
            currentPressurePlate = other.GetComponent<PressurePlateActiveCheck>();
            nearbySwitch = other;
            textToggle.showText();
        }

        if (other.tag == "Interactable")
        {
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
            textToggle.hideText();
        }

        if (other.tag == ppString || other.tag == ppBool || other.tag == ppFloat || other.tag == ppInt)
        {
            currentPressurePlate = null;
            playerActions.canInteract = false;
            nearbySwitch = null;
            textToggle.hideText();
        }

        if (other.tag == "Interactable")
        {
            textToggle.hideText();
        }
    }

    // Function that handles picking up the block
    private void PickUp(Collider col)
    {
        GameObject block = col.transform.Find("Block").gameObject;

        // string
        if (col.tag == dtString)
        {
            if (playerActions.canInteract)
            {
                if (!playerInventory.hasStringBlock && Input.GetKeyDown(KeyCode.F))
                {
                    playerInventory.invCount = 1;
                    playerInventory.hasStringBlock = true;
                    block.SetActive(false);
                }
            }
        }

        // bool
        else if (col.tag == dtBool)
        {
            if (playerActions.canInteract)
            {
                if (!playerInventory.hasBoolBlock && Input.GetKeyDown(KeyCode.F))
                {
                    playerInventory.invCount = 1;
                    playerInventory.hasBoolBlock = true;
                    block.SetActive(false);
                }
            }
        }

        // int
        else if (col.tag == dtInt)
        {
            if (playerActions.canInteract)
            {
                if (!playerInventory.hasIntBlock && Input.GetKeyDown(KeyCode.F))
                {
                    playerInventory.invCount = 1;
                    playerInventory.hasIntBlock = true;
                    block.SetActive(false);
                }
            }
        }

        // float
        else if (col.tag == dtFloat)
        {
            if (playerActions.canInteract)
            {
                if (!playerInventory.hasFloatBlock && Input.GetKeyDown(KeyCode.F))
                {
                    playerInventory.invCount = 1;
                    playerInventory.hasFloatBlock = true;
                    block.SetActive(false);
                }
            }
        }
    }

    // Function that handles placing back the block on the platform
    private void PutBack(Collider col)
    {
        GameObject block = col.transform.Find("Block").gameObject;

        if (col.tag == dtString)
        {
            if (playerActions.canInteract)
            {
                if (playerInventory.hasStringBlock && Input.GetKeyDown(KeyCode.F))
                {
                    playerInventory.invCount = 0;
                    playerInventory.hasStringBlock = false;
                    block.SetActive(true);
                }
            }
        }

        else if (col.tag == dtBool)
        {
            if (playerActions.canInteract)
            {
                if (playerInventory.hasBoolBlock && Input.GetKeyDown(KeyCode.F))
                {
                    playerInventory.invCount = 0;
                    playerInventory.hasBoolBlock = false;
                    block.SetActive(true);
                }
            }
        }

        else if (col.tag == dtFloat)
        {
            if (playerActions.canInteract)
            {
                if (playerInventory.hasFloatBlock && Input.GetKeyDown(KeyCode.F))
                {
                    playerInventory.invCount = 0;
                    playerInventory.hasFloatBlock = false;
                    block.SetActive(true);
                }
            }
        }

        else if (col.tag == dtInt)
        {
            if (playerActions.canInteract)
            {
                if (playerInventory.hasIntBlock && Input.GetKeyDown(KeyCode.F))
                {
                    playerInventory.invCount = 0;
                    playerInventory.hasIntBlock = false;
                    block.SetActive(true);
                }
            }
        }
    }

    // Function to handle placing the block on a platform
    private void PlaceBlock(Collider col)
    {
        GameObject block = col.transform.Find("Block").gameObject;
        GameObject pressureplate = col.transform.Find("Pressure Plate").gameObject;
        Material platformMat = pressureplate.transform.Find("Platform").GetComponent<MeshRenderer>().material;
        Text blockErrorText = blockErrorUI.transform.Find("DialogueText").GetComponent<Text>();

        if (col.tag == ppString)
        {
            // If the character has the correct block & the plate is not active yet
            if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && playerInventory.hasStringBlock && !currentPressurePlate.isActive)
            {
                playerInventory.invCount = 0;
                currentPressurePlate.isActive = true;
                playerInventory.hasStringBlock = false;
                block.SetActive(true);
                platformMat.color = Color.green;
            }
            // If the character tries to put a block on an already active switch
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && currentPressurePlate.isActive)
            {
                StartCoroutine(BlockErrorMessage(blockErrorText, "It looks like this is already active. I should move on!"));
            }
            // If the character has the wrong blocks and tries to add it to this one
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && (playerInventory.hasBoolBlock || playerInventory.hasFloatBlock || playerInventory.hasIntBlock))
            {
                StartCoroutine(ErrorBlink(platformMat));
                StartCoroutine(BlockErrorMessage(blockErrorText, "This block doesn't belong here. I should put it back."));
            }
            // If the character doesn't have the block
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && !playerInventory.hasStringBlock)
            {
                StartCoroutine(ErrorBlink(platformMat));
                StartCoroutine(BlockErrorMessage(blockErrorText, "I don't have any blocks. I should go grab one."));
            }
        }

        else if (col.tag == ppBool)
        {
            // If the character has the correct block & the plate is not active yet
            if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && playerInventory.hasBoolBlock && !currentPressurePlate.isActive)
            {
                playerInventory.invCount = 0;
                currentPressurePlate.isActive = true;
                playerInventory.hasBoolBlock = false;
                block.SetActive(true);
                platformMat.color = Color.green;
            }
            // If the character tries to put a block on an already active switch
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && currentPressurePlate.isActive)
            {
                StartCoroutine(BlockErrorMessage(blockErrorText, "It looks like this is already active. I should move on!"));
            }
            // If the character has the wrong blocks and tries to add it to this one
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && (playerInventory.hasStringBlock || playerInventory.hasFloatBlock || playerInventory.hasIntBlock))
            {
                StartCoroutine(ErrorBlink(platformMat));
                StartCoroutine(BlockErrorMessage(blockErrorText, "This block doesn't belong here. I should put it back."));
            }
            // If the character doesn't have the block
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && !playerInventory.hasBoolBlock)
            {
                StartCoroutine(ErrorBlink(platformMat));
                StartCoroutine(BlockErrorMessage(blockErrorText, "I don't have any blocks. I should go grab one."));
            }
        }

        else if (col.tag == ppFloat)
        {
            // If the character has the correct block & the plate is not active yet
            if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && playerInventory.hasFloatBlock && !currentPressurePlate.isActive)
            {
                playerInventory.invCount = 0;
                currentPressurePlate.isActive = true;
                playerInventory.hasFloatBlock = false;
                block.SetActive(true);
                platformMat.color = Color.green;
            }
            // If the character tries to put a block on an already active switch
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && currentPressurePlate.isActive)
            {
                StartCoroutine(BlockErrorMessage(blockErrorText, "It looks like this is already active. I should move on!"));
            }
            // If the character has the wrong blocks and tries to add it to this one
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && (playerInventory.hasBoolBlock || playerInventory.hasStringBlock || playerInventory.hasIntBlock))
            {
                StartCoroutine(ErrorBlink(platformMat));
                StartCoroutine(BlockErrorMessage(blockErrorText, "This block doesn't belong here. I should put it back."));
            }
            // If the character doesn't have the block
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && !playerInventory.hasFloatBlock)
            {
                StartCoroutine(ErrorBlink(platformMat));
                StartCoroutine(BlockErrorMessage(blockErrorText, "I don't have any blocks. I should go grab one."));
            }
        }

        else if (col.tag == ppInt)
        {

            // If the character has the correct block & the plate is not active yet
            if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && playerInventory.hasIntBlock && !currentPressurePlate.isActive)
            {
                playerInventory.invCount = 0;
                currentPressurePlate.isActive = true;
                playerInventory.hasIntBlock = false;
                block.SetActive(true);
                platformMat.color = Color.green;
            }
            // If the character tries to put a block on an already active switch
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && currentPressurePlate.isActive)
            {
                StartCoroutine(BlockErrorMessage(blockErrorText, "It looks like this is already active. I should move on!"));
            }
            // If the character has the wrong blocks and tries to add it to this one
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && (playerInventory.hasBoolBlock || playerInventory.hasFloatBlock || playerInventory.hasStringBlock))
            {
                StartCoroutine(ErrorBlink(platformMat));
                StartCoroutine(BlockErrorMessage(blockErrorText, "This block doesn't belong here. I should put it back."));
            }
            // If the character doesn't have the block
            else if (playerActions.canInteract && Input.GetKeyDown(KeyCode.F) && !playerInventory.hasIntBlock)
            {
                StartCoroutine(ErrorBlink(platformMat));
                StartCoroutine(BlockErrorMessage(blockErrorText, "I don't have any blocks. I should go grab one."));
            }
        }
    }

    // Coroutine to handle create a "blink" effect
    IEnumerator ErrorBlink(Material mat)
    {
        Color prevColor = mat.color;
        Color errorColor = new Color32(146, 38, 38, 1);

        mat.color = errorColor;
        yield return new WaitForSeconds(1);
        mat.color = prevColor;
    }

    // Coroutine to handle the message for block placement error
    IEnumerator BlockErrorMessage(Text errorText, string message)
    {
        blockErrorUI.SetActive(true);
        errorText.text = message;
        yield return new WaitForSeconds(4);
        blockErrorUI.SetActive(false);
    }
}