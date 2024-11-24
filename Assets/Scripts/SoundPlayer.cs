using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private Button _button;

    private bool _buttonClicked = false;

    public bool SoundButtonClicked => _buttonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void SoundPlay()
    {
        _sound.Play();
    }

    public void SoundStop()
    {
        _sound.Stop();
    }

    private void OnButtonClick()
    {
        _buttonClicked = !_buttonClicked;       

        if (_sound.isPlaying == false)
        {
            SoundPlay();
        }
        else
        {
            SoundStop();
        }
    }
}