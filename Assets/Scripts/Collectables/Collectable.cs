using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{

    //[SerializeField] protected GameObject buttonsParent;
    //protected GameObject[] buttons;
    //[SerializeField] protected ScriptableList<ScriptableItem> _inventory;
    [SerializeField] protected ScriptableItem _scriptableItem;
    [SerializeField] protected int _amount;

    //public ScriptableList<ScriptableItem> Inventory { get => _inventory; set => _inventory = value; }
    public ScriptableItem ScriptableItem { get => _scriptableItem; set => _scriptableItem = value; }
    public int Amount { get => _amount; set => _amount = value; }

    /*protected void SetChildren() //quitar
    {
        buttons = new GameObject[buttonsParent.transform.childCount];
        for (int i = 0; i < buttonsParent.transform.childCount; i++)
        {
            buttons[i] = buttonsParent.transform.GetChild(i).gameObject;
        }
    }*/
   /* public void Interact()
    {
        Collect();
    }
    private void OnTriggerEnter(Collider other) //probar
    {
        if (other.gameObject.tag == "Player")
        {
            Collect();
        }
    }*/
    public ScriptableItem Collect()
    {
        /*if ((_inventory).Content.Contains(_scriptableItem))
            _scriptableItem.Amount += _amount;
        else
        {
            _inventory.Content.Add(_scriptableItem);
            //_inventory.OnValidate
        }*/
        return _scriptableItem;
        /*bool found = false;//quitar
        int j = 0;
        if (scriptableItem.Owned)
            scriptableItem.Amount += amount;
        else
        {
            do
            {
                var tal = buttonsParent.transform.GetChild(j).gameObject.GetComponent<GameItemButton>();
                if (buttons[j])
                    if (!buttons[j].activeSelf)
                    {
                        GameItemButton gameItemBut = buttons[j].GetComponent<GameItemButton>();
                        buttons[j].SetActive(true);
                        gameItemBut._item = scriptableItem;
                        gameItemBut.OnValidate();
                        found = true;
                    }
                j++;
            } while (!found && j < buttons.Length);
            if (found)
                this.gameObject.SetActive(false);
        }*/
    }


}
