using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    // Ссылка на компонент AudioSource
    public AudioSource audioSource;

    void Start()
    {
        // Получаем компонент AudioSource на том же GameObject
        audioSource = GetComponent<AudioSource>();

        // Проверяем, если компонент AudioSource отсутствует
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing on this GameObject. Please add an AudioSource component.");
        }
    }

    // Этот метод вызывается, когда курсор заходит на UI элемент
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Проигрываем звук
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
