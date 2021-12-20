using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public GameObject shopEnabler;

    public void enableShop()
    {
        shopEnabler.SetActive(true);
    }

    public void disableShop()
    {
        shopEnabler.SetActive(false);
    }
}
