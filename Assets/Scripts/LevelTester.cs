using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTester : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private LevelUI levelUI;
    // Update is called once per frame
   private void Awake()
    {
        ExpSystem expSystem = new ExpSystem();
        Debug.Log(expSystem.GetLevelNumber());
        expSystem.addExperience(50f);
        Debug.Log(expSystem.GetLevelNumber());
        expSystem.addExperience(60f);
        Debug.Log(expSystem.GetLevelNumber());

        levelUI.SetExpSystem(expSystem);
    }
}
