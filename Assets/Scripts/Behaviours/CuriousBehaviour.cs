using System;
using System.Collections.Generic;
using UnityEngine;

public class CuriousBehaviour : MonoBehaviour
{
    [SerializeField] private ConsumableDataBase _ownedConsumables;
    [SerializeField] private EquipDataBase _ownedEquipables;
    [SerializeField] private SkillDataBase _ownedSkills;
    private List<IInteractable> _interactables = new List<IInteractable>();
    private List<ICollectable> _icollectables = new List<ICollectable>();
    public ConsumableDataBase OwnedConsumables { get =>_ownedConsumables; set =>_ownedConsumables = value;}
    public EquipDataBase OwnedEquipables { get =>_ownedEquipables; set =>_ownedEquipables = value;}
    public SkillDataBase OwnedSkills { get =>_ownedSkills; set =>_ownedSkills = value;}
    public void Inspect()
    {
        foreach(IInteractable inter in _interactables)
                inter.Interact();
        foreach(ICollectable collec in _icollectables)
                TakeItem(collec.Collect());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
            _interactables.Add(interactable);
        if (other.TryGetComponent<ICollectable>(out var collectable))
            _icollectables.Add(collectable);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
            _interactables.Remove(interactable);
        if (other.TryGetComponent<ICollectable>(out var collectable))
            _icollectables.Remove(collectable);
    }

    void TakeItem(ScriptableItem item)
    {
        if(item is EquipItem)
        {
            if(_ownedEquipables.Content.Contains((EquipItem)item))
                _ownedEquipables.Content[_ownedEquipables.Content.IndexOf((EquipItem)item)].Amount+= item.Amount;
            else
            {
                _ownedEquipables.Content.Add((EquipItem)item); 
            }

        }

        else if (item is SkillItem)
        {
            if(_ownedSkills.Content.Contains((SkillItem)item))
                _ownedSkills.Content[_ownedSkills.Content.IndexOf((SkillItem)item)].Amount+= item.Amount;
            else
            {
                _ownedSkills.Content.Add((SkillItem)item); 
            }
            
        }

        else
        {
            if(_ownedConsumables.Content.Contains((ConsumableItem)item))
                _ownedConsumables.Content[_ownedConsumables.Content.IndexOf((ConsumableItem)item)].Amount+= item.Amount;
            else
            {
                _ownedConsumables.Content.Add((ConsumableItem)item);   
            }
      
        }
    }
}