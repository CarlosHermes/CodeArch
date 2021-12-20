using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject inventory;

   public void inventoryEnabler()
    {
        inventory.SetActive(true);
    }

    public void inventoryDisabler()
    {
        inventory.SetActive(false);
    }
}
