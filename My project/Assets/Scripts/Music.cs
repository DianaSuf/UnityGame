using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    //public Toggle toggleMusic;
    public Slider sliderVolumeMusic;
    public GameObject BGMusic1;
    private AudioSource audioSrc1;
    public float volume;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        audioSrc1 = BGMusic1.GetComponent<AudioSource>();
        Load();
        ValueMusic();

        //toggleMusic = GameObject.FindGameObjectWithTag("Toggle").GetComponent<Toggle>();
        sliderVolumeMusic = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
    }


    public void SliderMusic()
    {
        volume = sliderVolumeMusic.value;
        Save();
        ValueMusic();
    }

    //public void ToggleMusic()
    //{
    //    if (toggleMusic.isOn == true)
    //    {
    //        volume = 1;
    //    }
    //    else
    //    {
    //        volume = 0;
    //    }
    //    Save();
    //    ValueMusic();
    //}

    private void ValueMusic()
    {
        audioSrc1.volume = volume;
        sliderVolumeMusic.value = volume;
        //if (volume == 0) { toggleMusic.isOn = false; } else { toggleMusic.isOn = true; }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", volume);
    }

    private void Load()
    {
        volume = PlayerPrefs.GetFloat("volume", volume);
    }
}
