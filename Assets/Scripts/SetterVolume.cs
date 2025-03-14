using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class SetterVolume : MonoBehaviour
{
    private const int Value = 20;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerParametrs _parametrs;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        _slider.onValueChanged.AddListener(HandleVolumeChanged);
    }

    private void HandleVolumeChanged(float volume)
    {
        _audioMixer.SetFloat(_parametrs.ToString(), Mathf.Log10(volume) * Value);
    }
}
