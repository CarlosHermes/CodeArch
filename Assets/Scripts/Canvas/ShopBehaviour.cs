using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehaviour: MonoBehaviour
{
    [SerializeField] private IntVariable coins;
    [SerializeField] private SoundsListRandom _sounds;
    [SerializeField] private SkillDataBase _ownedSkills;
    private AudioSource _audioSource;
    [SerializeField] private int _amount =5;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void BuySkill(ShopItemButton itemShop)
    {
        if(coins.Value> itemShop._item.Price)
        {
            if(_ownedSkills.Content.Contains((SkillItem)itemShop._item))
            {
                _ownedSkills.Content[_ownedSkills.Content.IndexOf((SkillItem)itemShop._item)].Amount += _amount;
            }

            else
            {
                _ownedSkills.Content.Add((SkillItem)itemShop._item); 
            }
            coins.Value -= itemShop._item.Price;
            itemShop._item.Locked = false;
            int i = Random.Range(0, _sounds.Sounds.Count);
            _audioSource.clip = (_sounds.Sounds[i]);
            _audioSource.Play();
        }
        else //no debug log
        {
            Debug.Log("not enough coins");
        }
    }
}
