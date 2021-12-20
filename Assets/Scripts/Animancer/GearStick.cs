using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GearStick : ActionAnims, IInteractable
{
    public event Action<int> doorChange = delegate { };
    private bool opened = false;
    private bool interacted = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!interacted)
        {
            if (other.tag == "Player")
            {
                interacted = true;
                Interact();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        interacted = false;
    }
    public void Interact()
    {
        if (!opened)
            Open();
        else
            Close();
        opened = !opened;
    }
    public void Open()
    {
        base.Open();
        doorChange.Invoke(1);
    }
    public void Close()
    {
        base.Close();
        doorChange.Invoke(-1);
    }
}
