using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixer; // Ссылка на ваш AudioMixer
    public Slider masterSlider; // Ссылка на ползунок общего звука
    public Slider musicSlider; // Ссылка на ползунок музыки
    public Slider sfxSlider; // Ссылка на ползунок эффектов
    public Slider uiSlider; // Ссылка на ползунок UI

    void Start()
    {
        // Установите начальные значения ползунков
        SetInitialSliderValue("MasterVolume", masterSlider);
        SetInitialSliderValue("MusicVolume", musicSlider);
        SetInitialSliderValue("SFXVolume", sfxSlider);
        SetInitialSliderValue("UIVolume", uiSlider);

        // Добавьте слушатели для изменения значений ползунков
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        uiSlider.onValueChanged.AddListener(SetUIVolume);
    }

    void SetInitialSliderValue(string parameterName, Slider slider)
    {
        float volume;
        if (audioMixer.GetFloat(parameterName, out volume))
        {
            slider.value = Mathf.Pow(10, volume / 20); // Преобразуем из дБ в линейное значение
        }
        else
        {
            Debug.LogWarning("Parameter " + parameterName + " not found in AudioMixer.");
        }
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80,0,volume)); // Преобразуем линейное значение в дБ
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume)); // Преобразуем линейное значение в дБ
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Lerp(-80, 0, volume)); // Преобразуем линейное значение в дБ
    }

    public void SetUIVolume(float volume)
    {
        audioMixer.SetFloat("UIVolume", Mathf.Lerp(-80, 0, volume)); // Преобразуем линейное значение в дБ
    }
}
