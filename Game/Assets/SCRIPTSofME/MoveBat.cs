using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Transform startPoint; // Начальная точка
    public Transform endPoint;   // Конечная точка
    public float speed = 1.0f;   // Скорость перемещения
    public float delay = 2.0f;   // Задержка перед началом движения

    private float startTime;
    private float journeyLength;
    private bool isMoving = false;
    private AudioSource audioSource; // Компонент AudioSource для воспроизведения звука перемещения



    void Start()
    {
        // Определение начальной и конечной позиций
        transform.position = startPoint.position;
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        startTime = Time.time + delay; // Задержка перед началом движения

        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();
      
    }

    void Update()
    {
        if (!isMoving && Time.time >= startTime)
        {
            isMoving = true;

            // Воспроизводим звук перемещения
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }

        if (isMoving)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, fracJourney);

            if (fracJourney >= 1.0f)
            {
                // Достигнута конечная точка, возвращаемся на начальную точку и поворачиваемся на 180 градусов
                var temp = startPoint;
                startPoint = endPoint;
                endPoint = temp;
                startTime = Time.time + delay; // Задержка перед повторным началом движения
                isMoving = false;
                // Поворот на 180 градусов
                transform.Rotate(Vector3.up, 180f);
            }
        }
    }
}
