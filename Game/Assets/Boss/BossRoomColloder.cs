using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomManager : MonoBehaviour
{
    public List<BossScript> enemies; // ������ ���� ����������� � �������
    public GameObject chest; // ������ �� ������
    public GameObject teleport; // ������ �� �������� �� 2-� �������
                                // public event System.Action OnDeath;

    public GameObject dialogBox;
    public GameObject woodflor;

    public AudioSource BossfightMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogBox.SetActive(true);
            BossfightMusic.Play();
        }
    }

    private void Update()
    {
        foreach (BossScript enemy in enemies)
        {
            if (enemy.HP <= 100)
            {
                woodflor.SetActive(false);
                break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogBox.SetActive(false);
            BossfightMusic.Stop();
        }
    }

    private void Start()
    {
        // ������������� �� ������� ������ �����������
        foreach (BossScript enemy in enemies)
        {
            enemy.OnDeath += CheckEnemiesHealth;
        }
    }

    // �����, ���������� ��� ������ ����������
    private void CheckEnemiesHealth()
    {
        bool allEnemiesDead = true;

        // ��������� �������� ������� ����������
        foreach (BossScript enemy in enemies)
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
            BossfightMusic.Stop();
            //teleport.SetActive(true);
            //chest.SetActive(true);
        }
    }
}
