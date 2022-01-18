using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().color = new Color(0, 0, 0, 0);
    }

    public void hideText()
    {
        this.GetComponent<Text>().color = new Color(0, 0, 0, 0);
    }

    public void showText()
    {
        this.GetComponent<Text>().color = new Color(255, 255, 255, 1);
    }
}
