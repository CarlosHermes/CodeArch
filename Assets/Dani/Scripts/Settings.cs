using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
   public GameObject settingsUI;
   
   public void settingsEnabler()
   {
       settingsUI.SetActive(true);
   }

   public void settingsDisabler()
   {
       settingsUI.SetActive(false);
   }


}
