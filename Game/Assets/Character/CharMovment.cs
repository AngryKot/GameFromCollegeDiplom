using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovment : MonoBehaviour
{
    public GameObject MainCamera; //����� ������� ������ ��� ��������� ������� ����������� ��������
    public GameObject Player; //������ �����

    public static bool _gameover; //������� ���������

    private float speed; //�������� �����������
    private Rigidbody rb; //���������� ����
    private bool grounded; // �� ����� �� ��������?
    private bool moveForward; // ��������� ������ ��������?
    private bool moveBack; // ��������� ����� ��������?
    private bool moveRight; // ��������� ����� ��������?
    private bool moveLeft; // ��������� ����� ��������?

    //������ ���������� ��� ������ ����
    void Start()
    {
        grounded = true;
        rb = Player.GetComponent<Rigidbody>();
        _gameover = false;
        speed = 300;
        moveForward = false;
        moveBack = false;
        moveRight = false;
        moveLeft = false;
    }

    //������ ������, ��� ������ ������ �������� ��� ������� ��������

    void Update()
    {
        //��������� ������ �� ������� ������
        if (Input.GetKey(KeyCode.W) & _gameover == false)
        {
            moveForward = true;
            if (grounded == true)
            {
                rb.AddForce(MainCamera.transform.forward * speed * Time.deltaTime);
            }
            else
            {
                rb.AddForce(0f, 0f, 0f);
            }
        }
        else
        {
            moveForward = false;
        }
        //�������� ����� �� ������� ������
        if (Input.GetKey(KeyCode.S) & _gameover == false)
        {
            if (grounded == true)
            {
                rb.AddForce(-MainCamera.transform.forward * speed * Time.deltaTime);
                moveBack = true;
            }
            else
            {
                rb.AddForce(0f, 0f, 0f);
            }
        }
        else
        {
            moveBack = false;
        }

        //�������� ������ �� ������� ������
        if (Input.GetKey(KeyCode.D) & _gameover == false)
        {
            if (grounded == true)
            {
                rb.AddForce(MainCamera.transform.right * speed * Time.deltaTime);
                moveRight = true;
            }
            else
            {
                rb.AddForce(0f, 0f, 0f);
            }
        }
        else
        {
            moveRight = false;
        }
        //�������� ����� �� ������� ������
        if (Input.GetKey(KeyCode.A) & _gameover == false)
        {
            if (grounded == true)
            {
                rb.AddForce(-MainCamera.transform.right * speed * Time.deltaTime);
                moveLeft = true;
            }
            else
            {
                rb.AddForce(0f, 0f, 0f);
            }
        }
        else
        {
            moveLeft = false;
        }
    }
}
