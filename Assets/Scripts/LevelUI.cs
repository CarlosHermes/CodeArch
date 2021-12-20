using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Text levelText;
    public Image experienceBarImage;
    private ExpSystem expSystem;
    private Slider slider;
    // Start is called before the first frame update
    private void Awake()
    {  
        slider = GetComponent<Slider>();
        slider.maxValue = expSystem.expToNextLevel;
        SetExperienceBarSize(.5f);
        SetLevelNumber(1);
    }

    private void SetExperienceBarSize(float experienceNormalized)
    {
        experienceBarImage.fillAmount = experienceNormalized;

    }
    
    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "LEVEL\n" + (levelNumber + 1);
    }
    
    public void SetExpSystem(ExpSystem expSystem)
    {
        //Setter del objeto ExpSystem
        this.expSystem = expSystem;

        //Actualizador de datos
        SetLevelNumber(expSystem.GetLevelNumber());
        SetExperienceBarSize(expSystem.GetExperienceNormalized());

        //Suscripción a los eventos cambiados
        expSystem.OnExperienceChanged += ExpSystem_OnExperienceChanged;
        expSystem.OnLevelChanged += expSystem_OnLevelChanged;
    }

    
    private void expSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        //Cambio de nivel, cambio de texto
        throw new System.NotImplementedException();
    }

    private void ExpSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        //Experiencia cambiada, actualizar barra
        throw new System.NotImplementedException();
    }
    
}
