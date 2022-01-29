using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    // Bools to see if we have blocks
    public bool hasStringBlock = false;
    public bool hasBoolBlock = false;
    public bool hasFloatBlock = false;
    public bool hasIntBlock = false;

    // Int to keep a count on the inventory
    public int invCount = 0;

    // Text object to update the currently held item
    public GameObject itemTextObj;
    public Text itemText;


    void Awake()
    {
        itemTextObj = GameObject.Find("ItemText");
        if (itemTextObj != null)
        {
            itemText = itemTextObj.GetComponent<Text>();
        }
    }


    void Update()
    {
        if (itemText != null)
        {
            if (invCount > 0)
            {
                // Change the holding text to the correct block
                if (hasStringBlock)
                {
                    itemText.text = "String Block";
                }
                else if (hasBoolBlock)
                {
                    itemText.text = "Bool Block";
                }
                else if (hasFloatBlock)
                {
                    itemText.text = "Float Block";
                }
                else if (hasIntBlock)
                {
                    itemText.text = "Int Block";
                }
            }
            else
            {
                itemText.text = "Nothing";
            }
        }
    }
}
