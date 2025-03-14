using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ToggleMasterSound : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";
    private const int MaxVolume = 0;
    private const int MinVolume = -80;

    [SerializeField] private AudioMixer _audioMixer;

    private Button _button;

    private bool _isMasterSoundOn = true;

    private void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(ToggleSound);
    }

    private void ToggleSound()
    {
        _isMasterSoundOn = !_isMasterSoundOn;

        _audioMixer.SetFloat(MasterVolume, _isMasterSoundOn ? MaxVolume : MinVolume);
    }
}
