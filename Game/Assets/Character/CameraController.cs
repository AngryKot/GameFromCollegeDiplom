using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ������ �� ������ ���������
    public float distance = 5.0f; // ���������� �� ������ �� ���������
    public float minDistance = 2.0f; // ����������� ���������� ���������� �� ���������
    public float maxDistance = 5.0f; // ������������ ���������� ���������� �� ���������
    public float zoomSpeed = 5.0f; // �������� �����������/�������� ������

    private RaycastHit hit;

    void Update()
    {
        // ���������, ���� �� ����������� ����� ������� � ����������
        if (Physics.Raycast(target.position, -transform.forward, out hit, maxDistance))
        {
            // ���� ����������� ����������, ���������� ������ � ��������� �� ���������� �� �����
            distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            // ���� ����������� ���, ������������� ���������� �� ��������� � ������������ ��������
            distance = maxDistance;
        }

        // ������ ����������/������� ������ �� ���������
        transform.position = Vector3.Lerp(transform.position, target.position - transform.forward * distance, Time.deltaTime * zoomSpeed);
    }

    public bool lockCursor;
    public float mouseSensitivity = 10;
    //public Transform target;
    //public float dstFromTarget = 2;
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float yaw;
    float pitch;

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        //transform.position = target.position - transform.forward * dstFromTarget;

    }
}