using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryReset : MonoBehaviour
{
    public bool passedThrough;
    private PlayerInventory playerInventory;

    void Awake()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (!passedThrough && col.tag == "Player")
        {
            passedThrough = true;
            playerInventory.hasBoolBlock = false;
            playerInventory.hasFloatBlock = false;
            playerInventory.hasIntBlock = false;
            playerInventory.hasStringBlock = false;
            playerInventory.invCount = 0;
            Debug.Log("Player passed through the Inventory Reset");
        }
    }
}
