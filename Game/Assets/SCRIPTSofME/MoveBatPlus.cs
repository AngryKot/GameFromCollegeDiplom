using UnityEngine;

public class Moving3Object : MonoBehaviour
{
    public Transform[] waypoints; // ������ �����
    public float speed = 1.0f;    // �������� �����������
    public float delay = 2.0f;    // �������� ����� ������� ��������
    public AudioClip movementSound; // ��������� ��� ����� �����������
    private AudioSource audioSource; // ��������� AudioSource ��� ��������������� ����� �����������

    private int currentWaypointIndex = 0;
    private float startTime;
    private float journeyLength;
    private bool isMoving = false;



    void Start()
    {
        // ��������� ��������� �������
        transform.position = waypoints[0].position;
        startTime = Time.time + delay; // �������� ����� ������� ��������

        // ��������� ���������� AudioSource ��� ��� ��������, ���� ��� ���
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ��������� AudioSource
        audioSource.clip = movementSound;


    }

    void Update()
    {
        if (!isMoving && Time.time >= startTime)
        {
            isMoving = true;

            // ��������������� ����� �����������
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

            // ����������� � ������� �����
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // ���� ������ ������ �����, �������������� �� 90 ��������
            if (distToWaypoint < 0.001f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                startTime = Time.time + delay; // �������� ����� ��������� ������������
                isMoving = false;
                // ������� �� 180 ��������
                transform.Rotate(Vector3.up, 90f);
            }
        }
    }
}
