using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<EnemyScript> enemies; // ������ ���� ����������� � �������
    public GameObject chest; // ������ �� ������
    public GameObject teleport; // ������ �� �������� �� 2-� �������
                                // public event System.Action OnDeath;
    public AudioSource room1audio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            room1audio.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            room1audio.Stop();
        }
    }
    private void Start()
    {
        // ������������� �� ������� ������ �����������
        foreach (EnemyScript enemy in enemies)
        {
            enemy.OnDeath += CheckEnemiesHealth;
        }
    }

    // �����, ���������� ��� ������ ����������
    private void CheckEnemiesHealth()
    {
        bool allEnemiesDead = true;

        // ��������� �������� ������� ����������
        foreach (EnemyScript enemy in enemies)
        {
            if (enemy.HP > 0)
            {
                chest.SetActive(false);
                allEnemiesDead = false;
                break;
            }
        }

        // ���� �������� ���� ����������� ���������� �� 0, �� ���������� ������
        if (allEnemiesDead)
        {
            teleport.SetActive(true);
            chest.SetActive(true);
        }
    }
}
