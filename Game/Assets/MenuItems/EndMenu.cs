using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public float startVolume = 0.1f; // ��������� ����� ��� �������
    public void LoadLevel()
    {
        SceneManager.LoadScene("Save12PlayerHealth");// � �������� �������� ����� �� ������� �������������� �������
    }

    public void ExitGame()
    {
        Debug.Log("���� ���������");
        Application.Quit();
    }
}