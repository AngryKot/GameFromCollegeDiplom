using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixer; // ������ �� ��� AudioMixer
    public Slider masterSlider; // ������ �� �������� ������ �����
    public Slider musicSlider; // ������ �� �������� ������
    public Slider sfxSlider; // ������ �� �������� ��������
    public Slider uiSlider; // ������ �� �������� UI

    void Start()
    {
        // ���������� ��������� �������� ���������
        SetInitialSliderValue("MasterVolume", masterSlider);
        SetInitialSliderValue("MusicVolume", musicSlider);
        SetInitialSliderValue("SFXVolume", sfxSlider);
        SetInitialSliderValue("UIVolume", uiSlider);

        // �������� ��������� ��� ��������� �������� ���������
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
            slider.value = Mathf.Pow(10, volume / 20); // ����������� �� �� � �������� ��������
        }
        else
        {
            Debug.LogWarning("Parameter " + parameterName + " not found in AudioMixer.");
        }
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80,0,volume)); // ����������� �������� �������� � ��
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume)); // ����������� �������� �������� � ��
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Lerp(-80, 0, volume)); // ����������� �������� �������� � ��
    }

    public void SetUIVolume(float volume)
    {
        audioMixer.SetFloat("UIVolume", Mathf.Lerp(-80, 0, volume)); // ����������� �������� �������� � ��
    }
}
