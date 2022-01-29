using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class PlayerActions : MonoBehaviour
{
    public bool canInteract = false;
    public bool interacting = false;
    public bool gamePaused = false;

    public GameObject pauseMenu;

    void Awake()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

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

        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gamePaused = true;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gamePaused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
