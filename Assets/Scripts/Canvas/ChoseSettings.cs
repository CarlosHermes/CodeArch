using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseSettings : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollBar;
    public void Awake()
    {
        _scrollBar.value = PlayerPrefs.GetFloat("Volume", 1f);
    }
    public void SetVolume()
    {
        PlayerPrefs.SetFloat("Volume", _scrollBar.value);
        AudioListener.volume = _scrollBar.value;
    }
}
