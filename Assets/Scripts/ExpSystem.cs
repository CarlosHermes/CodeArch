using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSystem
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    public float expToNextLevel;
    public float currentExp;
    public float updatedExp = 0f;
    public float expExponential;

    public IntVariable expScriptable;
    
    public int playerLevel;

    public Image expBar;

    public Text levelText;

    // Start is called before the first frame update
 
    public void LevelSystem()
    {
        playerLevel = 1;
        currentExp = 0f;
        expExponential = 1.2f;
        expToNextLevel = 100f;

    }
    public void addExperience(float amount)
    {
        currentExp += amount;
        if (currentExp >= expToNextLevel)
        {
            playerLevel++;
            currentExp = 0;
            nextLevelMultiplier();
            if (OnLevelChanged != null) OnExperienceChanged(this, EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    public void nextLevelMultiplier()
    {
        expToNextLevel = expToNextLevel * expExponential;
    }

    public int GetLevelNumber()
    {
        return playerLevel;
    }

    public float GetExperienceNormalized()
    {
        return (float) currentExp / expToNextLevel;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
