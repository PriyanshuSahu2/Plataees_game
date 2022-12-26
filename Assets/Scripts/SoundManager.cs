using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    
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
            levelsAudioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.15f);
            soundEffectsSlider.value = levelsAudioSource.volume;
    }
    public void SetAudioSettings()
    {
        levelsAudioSource.volume = soundEffectsSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", soundEffectsSlider.value);
    }
}
