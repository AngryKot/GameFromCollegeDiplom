using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Transform startPoint; // ��������� �����
    public Transform endPoint;   // �������� �����
    public float speed = 1.0f;   // �������� �����������
    public float delay = 2.0f;   // �������� ����� ������� ��������

    private float startTime;
    private float journeyLength;
    private bool isMoving = false;
    private AudioSource audioSource; // ��������� AudioSource ��� ��������������� ����� �����������



    void Start()
    {
        // ����������� ��������� � �������� �������
        transform.position = startPoint.position;
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        startTime = Time.time + delay; // �������� ����� ������� ��������

        // �������� ��������� AudioSource
        audioSource = GetComponent<AudioSource>();
      
    }

    void Update()
    {
        if (!isMoving && Time.time >= startTime)
        {
            isMoving = true;

            // ������������� ���� �����������
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
                // ���������� �������� �����, ������������ �� ��������� ����� � �������������� �� 180 ��������
                var temp = startPoint;
                startPoint = endPoint;
                endPoint = temp;
                startTime = Time.time + delay; // �������� ����� ��������� ������� ��������
                isMoving = false;
                // ������� �� 180 ��������
                transform.Rotate(Vector3.up, 180f);
            }
        }
    }
}
