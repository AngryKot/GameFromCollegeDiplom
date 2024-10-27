using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    // ������ �� ��������� AudioSource
    public AudioSource audioSource;

    void Start()
    {
        // �������� ��������� AudioSource �� ��� �� GameObject
        audioSource = GetComponent<AudioSource>();

        // ���������, ���� ��������� AudioSource �����������
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing on this GameObject. Please add an AudioSource component.");
        }
    }

    // ���� ����� ����������, ����� ������ ������� �� UI �������
    public void OnPointerEnter(PointerEventData eventData)
    {
        // ����������� ����
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
