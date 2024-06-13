using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {   if(PlayerPrefs.HasKey("musicVolume"))
        {
                Load()
        }
        else
        {
             SetChangeVolume();
        }
       
    }

    public void SetChangeVolume()
    {
        float volume = volumeSlider.value;
        myMixer.SetFloat("musicVolume", MAthf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetChangeVolume();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
