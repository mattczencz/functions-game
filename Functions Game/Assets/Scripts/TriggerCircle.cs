using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCircle : MonoBehaviour
{
    // Bool to see if player is in circle
    public bool inRange = false;
    
    // Reference to dialogue game object
    public GameObject dialogueBox;

    // Reference to CharacterController script
    public CharacterController charController;

    // Reference to TextToggle script
    public TextToggle textToggle;

    void Awake() {
        textToggle = GameObject.Find("InteractText").GetComponent<TextToggle>();
    }

    void Update()
    {
        if (inRange == true && charController.interacting == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                textToggle.hideText();
                charController.interacting = true;
                dialogueBox.SetActive(true);
            }
        }

        else if (inRange == true && charController.interacting == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                textToggle.showText();
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }
}
