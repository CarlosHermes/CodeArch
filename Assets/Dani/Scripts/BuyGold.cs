using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGold : MonoBehaviour
{
    [SerializeField] private SoundsListRandom _coinSounds;
    private AudioSource _audioSource;
    private int _nIngots = 1;
    private int _value = 100;
    public IntVariable coins;
    public IntVariable ingots;

    void Awake(){
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void BuyIngots()
    {
        ingots.Value += _nIngots;
        int i = Random.Range(0, _coinSounds.Sounds.Count);
        _audioSource.clip = (_coinSounds.Sounds[i]);
        _audioSource.Play();
    }
    public void BuyCoins()
    {
        if (ingots.Value>_nIngots)
        {
            coins.Value += _nIngots * _value;
            ingots.Value -= _nIngots;
            int i = Random.Range(0, _coinSounds.Sounds.Count);
            _audioSource.clip = (_coinSounds.Sounds[i]);
            _audioSource.Play();
        }
    }

}
