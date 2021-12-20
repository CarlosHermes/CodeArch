using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float minimum;
    public float current;
    public float maximum;
    public Image mask;
    [SerializeField] private IntVariable _exp;
    [SerializeField] private IntVariable _level;
    public void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
        if(current == maximum)
            UpdateLevel();
    }
    public void UpdateExp()
    {
        current = _exp.Value;
        GetCurrentFill();
    }
    public void UpdateLevel()
    {
        maximum = maximum+20;
        current = 0;
        _exp.Value = 0;
        _level.Value+=1;
    }
}
