using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // —сылка на объект персонажа
    public float distance = 5.0f; // –ассто€ние от камеры до персонажа
    public float minDistance = 2.0f; // ћинимальное допустимое рассто€ние до персонажа
    public float maxDistance = 5.0f; // ћаксимальное допустимое рассто€ние до персонажа
    public float zoomSpeed = 5.0f; // —корость приближени€/удалени€ камеры

    private RaycastHit hit;

    void Update()
    {
        // ѕровер€ем, есть ли преп€тствие между камерой и персонажем
        if (Physics.Raycast(target.position, -transform.forward, out hit, maxDistance))
        {
            // ≈сли преп€тствие обнаружено, приближаем камеру к персонажу на рассто€ние до стены
            distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            // ≈сли преп€тствий нет, устанавливаем рассто€ние до персонажа в максимальное значение
            distance = maxDistance;
        }

        // ѕлавно приближаем/удал€ем камеру от персонажа
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