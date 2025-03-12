using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource[] _soundEffects;
    [SerializeField] private AudioSource _backgroundMusic;

    [SerializeField] private Slider _masterVolume;
    [SerializeField] private Slider _sfxVolume;
    [SerializeField] private Slider _musicVolume;

    [SerializeField] private Button _masterSound;

    private bool _isMasterSoundOn = true;

    private void Start()
    {
        _masterVolume.onValueChanged.AddListener(SetMasterVolume);
        _sfxVolume.onValueChanged.AddListener(SetSFXVolume);
        _musicVolume.onValueChanged.AddListener(SetMusicVolume);

        _masterSound.onClick.AddListener(ToggleMasterSound);
    }

    public void PlaySound(int index)
    {
        if (index >= 0 && index < _soundEffects.Length)
        {
            _soundEffects[index].Play();
        }
    }

    private void SetMasterVolume(float volume)
    {
        _audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    private void SetSFXVolume(float volume)
    {
        _audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }

    private void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    private void ToggleMasterSound()
    {
        int maxValue = 0;
        int minValue = -80;

        _isMasterSoundOn = !_isMasterSoundOn;

        if (_isMasterSoundOn)
        {
            _audioMixer.SetFloat("MasterVolume", maxValue);
        }
        else
        {
            _audioMixer.SetFloat("MasterVolume", minValue);
        }
    }
}
