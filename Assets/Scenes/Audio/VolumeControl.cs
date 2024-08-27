using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;  // Reference to the slider
    public AudioSource audioSource;  // Reference to the audio source

    void Start()
    {
        // Set the slider's initial value to the current audio source volume
        volumeSlider.value = audioSource.volume;

        // Add a listener to the slider to detect changes in value
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Method to set the volume based on the slider's value
    void SetVolume(float value)
    {
        audioSource.volume = value;
    }
}