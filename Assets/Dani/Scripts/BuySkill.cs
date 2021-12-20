using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySkill : MonoBehaviour
{
    public SkillItem skill;
    public Text actualCoins;
    public GameObject buttonsParent;
    public void BuyTheSkill()
    {
        GameObject[] buttons = new GameObject[buttonsParent.transform.childCount];
        for (int i = 0; i < buttonsParent.transform.childCount; i++)
            buttons[i] = buttonsParent.transform.GetChild(i).gameObject;
        int coins = int.Parse(actualCoins.text);
        if (coins >= skill.Price)
        {
            bool found = false;
            int i = 0;
            do
            {
                if (!buttons[i].activeSelf)
                {
                    GameItemButton gameItemBut = buttons[i].GetComponent<GameItemButton>();
                    buttons[i].SetActive(true);
                    gameItemBut._item = skill;
                    gameItemBut.OnValidate();
                    found = true;
                }
                i++;
            } while (!found);
            int haveCoins = coins - skill.Price;
            actualCoins.text = "" + haveCoins;
            skill.Locked = false;
        }
        else
            Debug.Log("not enough coins");
    }
}
