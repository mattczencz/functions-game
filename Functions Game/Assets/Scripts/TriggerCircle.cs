using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCircle : MonoBehaviour
{
    public bool inRange = false;

    public GameObject dialogueBox;

    private GameObject interactText;
    
    public CharacterController charController;

    void Awake()
    {
        interactText = GameObject.Find("InteractText");
        interactText.SetActive(false);

        charController = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    void Update()
    {
        if (inRange == true && charController.interacting == false)
        {
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                interactText.SetActive(false);
                charController.interacting = true;
                dialogueBox.SetActive(true);
            }
        }

        else if (inRange == true && charController.interacting == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                interactText.SetActive(true);
                charController.interacting = false;
                dialogueBox.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            Debug.Log("Player can interact with NPC");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactText.SetActive(false);
            inRange = false;
            Debug.Log("Player can no longer interact with NPC");
        }
    }
}
