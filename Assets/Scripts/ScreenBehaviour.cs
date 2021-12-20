using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBehaviour : MonoBehaviour
{
    [SerializeField] private ScreenOrientation ScreenOrientation;
    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
            Screen.orientation = ScreenOrientation.Portrait;
    }
}
