using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("Main Menu Audios")]
    [SerializeField] AudioSource mainMenuAudioSource;
    

    [Header("Levels Audios")]
    [SerializeField] AudioSource levelsAudioSource;
    
    [Header("")]
    [SerializeField] Slider soundEffectsSlider;
    void Start()
    {
        levelsAudioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        GetAudioSettings();
    }
    private void OnEnable()
    {
        GetAudioSettings();
    }

    public void GetAudioSettings()
    {
        if(mainMenuAudioSource)
        {
            mainMenuAudioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.15f);
            soundEffectsSlider.value = mainMenuAudioSource.volume;
        }
        if (levelsAudioSource)
        {
            levelsAudioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.15f);
            soundEffectsSlider.value = levelsAudioSource.volume;
        }
    }
}
