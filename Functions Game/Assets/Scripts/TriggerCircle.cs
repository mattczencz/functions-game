using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCircle : MonoBehaviour
{
    public bool inRange = false;

    public GameObject dialogueBox;

    public CharacterController charController;

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
