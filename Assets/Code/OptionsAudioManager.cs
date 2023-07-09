using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsAudioManager : MonoBehaviour
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private TextMeshProUGUI volumeText;
    private static float volumeValue = 100f;

    private void Start()
    {
        soundSlider.value = volumeValue;
        volumeText.text = "Volume: " + volumeValue.ToString("F0");
    }
    public void SetVolumeFromSlider()
    {
        AdjustVolume(soundSlider.value);
    }

    public void AdjustVolume(float value)
    {
        volumeValue = value;
        AudioListener.volume = volumeValue / 100;
        volumeText.text = "Volume: " + volumeValue.ToString("F0");
    }
}
