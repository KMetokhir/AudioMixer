using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class OnOffSoundButton : MonoBehaviour
{
    [SerializeField] private Button _onOffButton;
    [SerializeField] private List<SoundPlayer> _soundPlayers = new List<SoundPlayer>();
    [SerializeField] private AudioSource _ambientSound;

    private bool _isPressed = false;

    private void OnEnable()
    {
        _onOffButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _onOffButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (_isPressed)
        {
            PlayAllSounds();
        }
        else
        {
            StopAllSounds();
        }

        _isPressed = !_isPressed;
    }

    private void PlayAllSounds()
    {
        if (_ambientSound.isPlaying == false)
        {
            _ambientSound.Play();
        }

        foreach (SoundPlayer soundPlayer in _soundPlayers)
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

        foreach (SoundPlayer soundPlayer in _soundPlayers)
        {
            soundPlayer.SoundStop();
        }
    }
}