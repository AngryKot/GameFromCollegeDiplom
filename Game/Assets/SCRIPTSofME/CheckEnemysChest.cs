using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<EnemyScript> enemies; // Список всех противников в комнате
    public GameObject chest; // Ссылка на сундук
    public GameObject teleport; // Ссылка на телепорт во 2-ю комнату
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
        // Подписываемся на событие смерти противников
        foreach (EnemyScript enemy in enemies)
        {
            enemy.OnDeath += CheckEnemiesHealth;
        }
    }

    // Метод, вызываемый при смерти противника
    private void CheckEnemiesHealth()
    {
        bool allEnemiesDead = true;

        // Проверяем здоровье каждого противника
        foreach (EnemyScript enemy in enemies)
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
            teleport.SetActive(true);
            chest.SetActive(true);
        }
    }
}
