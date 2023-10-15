using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _sound;
    [SerializeField] private AudioClip[] _sounds;
    void Start()
    {
        _music.Play();
        EventController.Instance.Damage.AddListener(SoundDamage);
        EventController.Instance.FructPickUp.AddListener(PickUp);
    }

    private void PickUp(int arg0)
    {
        _sound.clip = _sounds[1];
        _sound.Play();
    }

    private void SoundDamage(int i)
    {
        _sound.clip = _sounds[0];
        _sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
