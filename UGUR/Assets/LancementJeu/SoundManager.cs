using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {   if(PlayerPrefs.HasKey("music"))
        {
            Load();
        }
        else
        {
             SetChangeVolume();
        }
       
    }

    public void SetChangeVolume()
    {
        float volume = volumeSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("music", volume);
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("music");
        SetChangeVolume();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("music", volumeSlider.value);
    }
}
