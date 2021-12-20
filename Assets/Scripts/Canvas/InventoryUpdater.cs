using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUpdater : MonoBehaviour
{

    private void OnEnable()
    {
        GameItemButton[] buttons = transform.GetComponentsInChildren<GameItemButton>();
        foreach (GameItemButton button in buttons)
            button.UpdateSelf();
        InventoryCanvas[] canv = transform.GetComponentsInChildren<InventoryCanvas>();
        foreach (InventoryCanvas can in canv)
        {
            can.UpdateSelf();
            Debug.Log(can);
        }

    }
}
