using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ActionAnims
{
    [SerializeField] private GearStick _gearStick;

    private void OnEnable()
    {
        _gearStick.doorChange += ChangeDoorState;
    }
    private void OnDisable()
    {
        _gearStick.doorChange -= ChangeDoorState;
    }
    public void ChangeDoorState(int i)
    {
        if (i < 0)
            Close();
        else
            Open();
    }
}
