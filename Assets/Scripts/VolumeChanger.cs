using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioGroup;
    [SerializeField] private Slider _volumeSlider;

    private string _audioGroupVolumeParameter;
    private AudioMixer _audioMixer;

    private void Awake()
    {
        _audioMixer = _audioGroup.audioMixer;
        _audioGroupVolumeParameter = GetAudioGroupVolumParameter(_audioGroup);
    }

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(delegate { OnValueChanged(_volumeSlider, _audioGroupVolumeParameter); });
    }

    private void Start()
    {
        OnValueChanged(_volumeSlider, _audioGroupVolumeParameter);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(delegate { OnValueChanged(_volumeSlider, _audioGroupVolumeParameter); });
    }

    private void OnValueChanged(Slider slider, string audioGroupName)
    {
        float volume = Mathf.Log10(slider.value) * 20;
        _audioMixer.SetFloat(audioGroupName, volume);
    }

    private string GetAudioGroupVolumParameter(AudioMixerGroup group)
    {
        const string volume = "Volume";
        return group.name + volume;
    }
}