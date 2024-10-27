using UnityEngine;

public class ShowCanvasOnTrigger : MonoBehaviour
{
    public Canvas canvasToShow;

    private void Start()
    {
        // Начально скрываем Canvas
        if (canvasToShow != null)
        {
            canvasToShow.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что объект, вошедший в коллайдер, является игроком или другим объектом, который должен вызывать отображение Canvas
        if (other.CompareTag("Player"))
        {
            // Показываем Canvas
            if (canvasToShow != null)
            {
                canvasToShow.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Проверяем, что объект, вышедший из коллайдера, является игроком или другим объектом, который должен вызывать скрытие Canvas
        if (other.CompareTag("Player"))
        {
            // Скрываем Canvas
            if (canvasToShow != null)
            {
                canvasToShow.enabled = false;
            }
        }
    }
}