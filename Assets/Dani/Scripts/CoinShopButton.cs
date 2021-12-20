using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinShopButton : MonoBehaviour
{
    public GameObject coinShop;

    public void CoinShopEnabler()
    {
        coinShop.SetActive(true);
    }
    public void CoinShopDisabler()
    {
        coinShop.SetActive(false);
    }
}
