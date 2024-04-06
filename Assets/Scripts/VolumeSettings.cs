using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Text volumeTextUI = null;

    private void Start()
    {
        LoadValues();
    }
    public void volumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");

    }

    public SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
        LoadValues();
    }

    void LoadValues(){
        float volumeValue = PlayerPrefs.GetFloat("volumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
