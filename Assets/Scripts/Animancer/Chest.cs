using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : ActionAnims, IInteractable, ICollectable
{
    private bool opened = false;
    private bool firstOpen = true;
    [SerializeField] private ScriptableItem _loot;
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _audioSource;
    private bool interacted = false;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
    }

    public ScriptableItem Collect()
    {
        if (firstOpen)
        { 
            firstOpen = false;
            return _loot;
        }
        return null;
    }
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
        _audioSource.Play();
        if (!opened)
        {
            Open();
        }
        else
        {
            Close();
        }
        opened = !opened;
    }
}
