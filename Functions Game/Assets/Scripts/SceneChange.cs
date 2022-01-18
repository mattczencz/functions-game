using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Bool to see if player is in circle
    public bool inRange = false;

    // Reference to TextToggle script
    public TextToggle textToggle;

    void Awake()
    {
        textToggle = GameObject.Find("InteractText").GetComponent<TextToggle>();
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            Debug.Log(inRange);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            Debug.Log(inRange);
        }
    }
}
