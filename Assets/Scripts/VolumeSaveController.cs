using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSaveController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;  // Viittaus liukusäätimeen, jolla asetetaan äänenvoimakkuus.
    [SerializeField] private Text volumeTextUI = null;   // Viittaus tekstikenttään, jossa näytetään äänenvoimakkuusprosentti.

    private void Start()
    {
        LoadValues();  // Ladataan tallennetut arvot, kun skripti käynnistyy.
    }

    // Metodi, joka päivittää tekstikenttään asetetun äänenvoimakkuusprosentin ja tallentaa äänenvoimakkuuden.
    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
        SaveVolumeButton();
    }

    // Metodi, joka tallentaa liukusäätimen asettaman äänenvoimakkuuden PlayerPrefs-tietokantaan.
    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();  // Ladataan tallennetut arvot.
    }

    // Metodi, joka lataa tallennetut äänenvoimakkuusasetukset ja päivittää liukusäätimen sekä äänilähteen arvot.
    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;  // Päivitetään liukusäätimen arvo tallennetulla arvolla.
        AudioListener.volume = volumeValue;  // Päivitetään äänilähteen arvo tallennetulla arvolla.
    }
}
