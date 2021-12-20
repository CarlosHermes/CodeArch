using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New ListSounds", menuName = "ScriptableObjects/Sounds")]
public class SoundsListRandom : ScriptableObject
{
    [SerializeField] List<AudioClip> _sounds;

    public List<AudioClip> Sounds { get => _sounds; set => _sounds = value; }
    public AudioClip RandomSound()
    {
        return _sounds[(int)Mathf.Round(Random.Range(0, _sounds.Count))];
    }
}
