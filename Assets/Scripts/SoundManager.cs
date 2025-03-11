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

    [SerializeField] private Button[] _sounds;
    [SerializeField] private Button _masterSound;

    private bool _isMasterSoundOn = true;
    private bool[] _isSoundsOn;

    private void Start()
    {
        _isSoundsOn = new bool[_soundEffects.Length];

        for (int i = 0; i < _soundEffects.Length; i++)
        {
            _isSoundsOn[i] = true;
        }

        _masterVolume.onValueChanged.AddListener(SetMasterVolume);
        _sfxVolume.onValueChanged.AddListener(SetSFXVolume);
        _musicVolume.onValueChanged.AddListener(SetMusicVolume);

        for(int i = 0; i < _sounds.Length; i++)
        {
            int soundIndex = i;
            _sounds[i].onClick.AddListener(() => ToggleSound(soundIndex));
        }

        _masterSound.onClick.AddListener(ToggleMasterSound);
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

    private void ToggleSound(int index)
    {
        if (index >= 0 && index < _soundEffects.Length)
        {
            _isSoundsOn[index] = !_isSoundsOn[index];
            _soundEffects[index].mute = !_isSoundsOn[index];
        }

        if (_isSoundsOn[index])
        {
            _soundEffects[index].Play();
        }
    }

    private void ToggleMasterSound()
    {
        _isMasterSoundOn = !_isMasterSoundOn;
        AudioListener.pause = !_isMasterSoundOn;
    }
}
