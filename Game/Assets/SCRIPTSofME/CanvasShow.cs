using UnityEngine;

public class ShowCanvasOnTrigger : MonoBehaviour
{
    public Canvas canvasToShow;

    private void Start()
    {
        // �������� �������� Canvas
        if (canvasToShow != null)
        {
            canvasToShow.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ��� ������, �������� � ���������, �������� ������� ��� ������ ��������, ������� ������ �������� ����������� Canvas
        if (other.CompareTag("Player"))
        {
            // ���������� Canvas
            if (canvasToShow != null)
            {
                canvasToShow.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ���������, ��� ������, �������� �� ����������, �������� ������� ��� ������ ��������, ������� ������ �������� ������� Canvas
        if (other.CompareTag("Player"))
        {
            // �������� Canvas
            if (canvasToShow != null)
            {
                canvasToShow.enabled = false;
            }
        }
    }
}