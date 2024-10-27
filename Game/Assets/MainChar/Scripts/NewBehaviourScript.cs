

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMoveWithCamera : MonoBehaviour
{
    public Camera mainCamera; // ������ �� ������, � ������� �� ������ ������� �������� ������
    public float speed = 10f; // �������� ������
    private Vector3 targetDirection; // �����������, � ������� ����� ������ ���������

    // Start is called before the first frame update
    void Start()
    {
        // �������� ������
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("No main camera found. Please add a Camera component to your player object.");
        }
    }

    // Update is called once per frame
    void Update()
    {

        // ��������� ����������� ������
        targetDirection = mainCamera.transform.forward;
       
         // �������� ������ � ����������� �� ��������� ������
        transform.Translate(targetDirection * speed * Time.deltaTime);
    }
}