using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider; // Odkaz na slider


    void Start()
    {
        // Načti hlasitost uloženou v nastavení (pokud je k dispozici)
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.5f);
        AudioListener.volume = volumeSlider.value;
        
        // Přidej posluchač události pro změnu hlasitosti
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Funkce pro změnu hlasitosti
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume); // Uloží hlasitost do nastavení
    }
}
