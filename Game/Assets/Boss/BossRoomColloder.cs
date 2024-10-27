using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomManager : MonoBehaviour
{
    public List<BossScript> enemies; // Список всех противников в комнате
    public GameObject chest; // Ссылка на сундук
    public GameObject teleport; // Ссылка на телепорт во 2-ю комнату
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
        // Подписываемся на событие смерти противников
        foreach (BossScript enemy in enemies)
        {
            enemy.OnDeath += CheckEnemiesHealth;
        }
    }

    // Метод, вызываемый при смерти противника
    private void CheckEnemiesHealth()
    {
        bool allEnemiesDead = true;

        // Проверяем здоровье каждого противника
        foreach (BossScript enemy in enemies)
        {
            if (enemy.HP > 0)
            {
                chest.SetActive(false);
                allEnemiesDead = false;
                break;
            }
        }

        // Если здоровье всех противников опустилось до 0, то появляется сундук
        if (allEnemiesDead)
        {
            BossfightMusic.Stop();
            //teleport.SetActive(true);
            //chest.SetActive(true);
        }
    }
}
