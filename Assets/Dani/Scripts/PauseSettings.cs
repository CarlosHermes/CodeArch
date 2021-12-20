using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSettings : MonoBehaviour
{
    public GameObject settingsPause;

    public void enablePauseSettings()
    {
        settingsPause.SetActive(true);
    }

    public void disablePauseSettings()
    {
        settingsPause.SetActive(false);
    }

}
