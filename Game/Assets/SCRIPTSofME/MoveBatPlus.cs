using UnityEngine;

public class Moving3Object : MonoBehaviour
{
    public Transform[] waypoints; // Массив точек
    public float speed = 1.0f;    // Скорость перемещения
    public float delay = 2.0f;    // Задержка перед началом движения
    public AudioClip movementSound; // Аудиоклип для звука перемещения
    private AudioSource audioSource; // Компонент AudioSource для воспроизведения звука перемещения

    private int currentWaypointIndex = 0;
    private float startTime;
    private float journeyLength;
    private bool isMoving = false;



    void Start()
    {
        // Установка начальной позиции
        transform.position = waypoints[0].position;
        startTime = Time.time + delay; // Задержка перед началом движения

        // Получение компонента AudioSource или его создание, если его нет
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Настройка AudioSource
        audioSource.clip = movementSound;


    }

    void Update()
    {
        if (!isMoving && Time.time >= startTime)
        {
            isMoving = true;

            // Воспроизведение звука перемещения
            if (audioSource != null && movementSound != null)
            {
                audioSource.Play();
            }
        }

        if (isMoving)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            float distToWaypoint = Vector3.Distance(transform.position, targetPosition);
            float step = speed * Time.deltaTime;

            // Перемещение к текущей точке
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Если объект достиг точки, поворачиваемся на 90 градусов
            if (distToWaypoint < 0.001f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                startTime = Time.time + delay; // Задержка перед следующим перемещением
                isMoving = false;
                // Поворот на 180 градусов
                transform.Rotate(Vector3.up, 90f);
            }
        }
    }
}
