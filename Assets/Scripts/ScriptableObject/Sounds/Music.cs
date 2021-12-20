using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Music", menuName = "ScriptableObjects/Music")]
public class Music : ScriptableObject
{
    [SerializeField] private AudioClip _musicClip;

    public AudioClip MusicClip { get => _musicClip; set => _musicClip = value; }
}
