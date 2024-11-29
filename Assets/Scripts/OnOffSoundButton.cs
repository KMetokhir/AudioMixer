using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class OnOffSoundButton : MonoBehaviour
{
    [SerializeField] private Toggle _onOffToggle;
    [SerializeField] private List<AudioPlayer> _soundPlayers = new List<AudioPlayer>();
    [SerializeField] private AudioSource _ambientSound;  

    private void OnEnable()
    {      
        _onOffToggle.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    private void OnDisable()
    {
        _onOffToggle.onValueChanged.RemoveListener(delegate { OnValueChanged(); });
    }

    private void OnValueChanged()
    {
        if (_onOffToggle.isOn)
        {
            PlayAllSounds();
        }
        else
        {
            StopAllSounds();
        }
    }

    private void PlayAllSounds()
    {
        if (_ambientSound.isPlaying == false)
        {
            _ambientSound.Play();
        }

        foreach (AudioPlayer soundPlayer in _soundPlayers)
        {
            if (soundPlayer.SoundButtonClicked)
            {
                soundPlayer.SoundPlay();
            }
        }
    }

    private void StopAllSounds()
    {
        if (_ambientSound.isPlaying)
        {
            _ambientSound.Stop();
        }

        foreach (AudioPlayer soundPlayer in _soundPlayers)
        {
            soundPlayer.SoundStop();
        }
    }
}