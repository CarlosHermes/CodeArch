using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItemShop : MonoBehaviour
{
    public SkillItem skill;
    public Image art;
    public Text namee;
    public Text value;

    void Start()
    {
        art.sprite = skill.Icon;
        namee.text = skill.Name;
        value.text = "" + skill.Price;
    }

}
