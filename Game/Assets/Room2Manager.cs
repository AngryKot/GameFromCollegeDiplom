using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Manager : MonoBehaviour
{
    //public List<EnemyScript> enemies; // ������ ���� ����������� � �������
    //public GameObject chest; // ������ �� ������
    //public GameObject teleport; // ������ �� �������� �� 2-� �������
    //                            // public event System.Action OnDeath;
    public AudioSource room2audio;
    public GameObject[] entitiesToActivate; // ������ ��������� ��� ���������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            room2audio.Play();
            foreach (GameObject entity in entitiesToActivate)
            {
                entity.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            room2audio.Stop();

            foreach (GameObject entity in entitiesToActivate)
            {
                entity.SetActive(false);
            }
        }
    }
    private void Start()
    {
        //// ������������� �� ������� ������ �����������
        //foreach (EnemyScript enemy in enemies)
        //{
        //    enemy.OnDeath += CheckEnemiesHealth;
        //}
    }

    // �����, ���������� ��� ������ ����������
    private void CheckEnemiesHealth()
    {
        //bool allEnemiesDead = true;

        //// ��������� �������� ������� ����������
        //foreach (EnemyScript enemy in enemies)
        //{
        //    if (enemy.HP > 0)
        //    {
        //        chest.SetActive(false);
        //        allEnemiesDead = false;
        //        break;
        //    }
        //}

        //// ���� �������� ���� ����������� ���������� �� 0, �� ���������� ������
        //if (allEnemiesDead)
        //{
        //    teleport.SetActive(true);
        //    chest.SetActive(true);
        //}
    }
}
