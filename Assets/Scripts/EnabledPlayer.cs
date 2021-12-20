using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }
}
