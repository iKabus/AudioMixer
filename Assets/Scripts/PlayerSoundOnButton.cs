using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))]
public class PlayerSoundOnButton : MonoBehaviour
{
    private Button _button;
    private AudioSource _audioSource;

    private void Start()
    {
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();

        _button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
    }
}
