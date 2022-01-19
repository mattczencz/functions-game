using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class PlayerActions : MonoBehaviour
{
    public bool canInteract = false;
    public bool interacting = false;

    void Update()
    {
        if (interacting == true)
        {
            GetComponent<vThirdPersonInput>().enabled = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            GetComponent<Animator>().SetFloat("InputMagnitude", 0);
        }
        else
        {
            GetComponent<vThirdPersonInput>().enabled = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
