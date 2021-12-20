using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _slot;
    [SerializeField] private ConsumableDataBase _ownedConsumables;
    [SerializeField] private EquipDataBase _ownedEquipables;
    [SerializeField] private SkillDataBase _ownedSkills;
    void OnEnable()
    {
        UpdateSelf();
    }
    public void UpdateSelf()
    {
        GameItemButton[] children = transform.GetComponentsInChildren<GameItemButton>();
        int i=0;

        foreach (EquipItem ei in _ownedEquipables.Content)
        {
            try{
                children[i++]._item= ei;
            }
            catch{
                GameObject newSon = Instantiate(_slot);
                newSon.transform.SetParent(this.transform);
                var tr = newSon.GetComponent<RectTransform>();
                tr.localScale = new Vector3(1f, 1f, 1f);
                if(newSon.TryGetComponent<GameItemButton>(out var gameItemButton)) gameItemButton.Item = ei;
                i++;
            }
        }
        foreach (ConsumableItem ci in _ownedConsumables.Content)
        {
            try{
                children[i++]._item= ci;
            }
            catch{
                GameObject newSon = Instantiate(_slot);
                newSon.transform.SetParent(this.transform);
                var tr = newSon.GetComponent<RectTransform>();
                tr.localScale = new Vector3(1f, 1f, 1f);
                if (newSon.TryGetComponent<GameItemButton>(out var gameItemButton)) gameItemButton.Item = ci;
                                i++;
            }
        }
        foreach (SkillItem si in _ownedSkills.Content)
        {
            try{
                children[i++]._item= si;
            }
            catch{
                GameObject newSon = Instantiate(_slot);
                newSon.transform.SetParent(this.transform);
                var tr = newSon.GetComponent<RectTransform>();
                tr.localScale = new Vector3(1f, 1f, 1f);
                if (newSon.TryGetComponent<GameItemButton>(out var gameItemButton)) gameItemButton.Item = si;
                                i++;
            }
        }
    }
}
