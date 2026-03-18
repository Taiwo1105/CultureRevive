using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    [Header("UI")]
    public Toggle muteToggle;   // ON = sound, OFF = mute
    public Slider volumeSlider; // 0–1 range

    private float lastVolumeBeforeMute = 1f;

    void Start()
    {
        // Initialize slider to the audio source volume
        volumeSlider.value = audioSource.volume;

        // Listeners
        muteToggle.onValueChanged.AddListener(OnMuteToggle);
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnMuteToggle(bool isOn)
    {
        if (isOn)
        {
            // Toggle ON = unmuted
            audioSource.volume = lastVolumeBeforeMute;
        }
        else
        {
            // Toggle OFF = muted
            lastVolumeBeforeMute = audioSource.volume;
            audioSource.volume = 0f;
        }
    }

    void OnVolumeChanged(float value)
    {
        audioSource.volume = value;

        // If user moves slider above 0, unmute automatically
        if (value > 0f && !muteToggle.isOn)
        {
            muteToggle.isOn = true;
        }

        // If slider hits 0, set toggle to mute
        if (value == 0f && muteToggle.isOn)
        {
            muteToggle.isOn = false;
        }
    }
}

