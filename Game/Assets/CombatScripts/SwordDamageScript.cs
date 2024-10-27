using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//public class SwordDamageScript : MonoBehaviour
//{
//    //public int damageAmount = 25;

//    //private void OnTriggerEnter(Collider other)
//    //{

//    //    if  (other.CompareTag("Enemy"))
//    //    {
//    //        // Проверяем, соприкасается ли наш объект с врагом


//    //            // Вызываем метод TakeDamage у компонента EnemyScript на объекте врага
//    //            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);

//    //    }
//    //}

//}

public class SwordDamageScript : MonoBehaviour
{
    public int damageAmount = 25;
    private bool canDamage = false;

    private void Update()
    {
        // Проверяем, была ли нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Если кнопка мыши была нажата, разрешаем наносить урон
            canDamage = true;
            // Запускаем корутину, чтобы отключить возможность нанесения урона через секунду
            StartCoroutine(DisableDamage());
        }
    }

    private IEnumerator DisableDamage()
    {
        // Ждем одну секунду
        yield return new WaitForSeconds(0.5f);
        // После прошествия секунды отключаем возможность нанесения урона
        canDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, соприкасается ли наш объект с врагом
        if (other.CompareTag("Enemy") && canDamage)
        {
            // Если разрешено наносить урон, вызываем метод TakeDamage у компонента EnemyScript на объекте врага
            other.GetComponent
              <EnemyScript>().TakeDamage(damageAmount);
        }
        if (other.CompareTag("Boss") && canDamage)
        {
            // Если разрешено наносить урон, вызываем метод TakeDamage у компонента EnemyScript на объекте врага
            other.GetComponent
              <BossScript>().TakeDamage(damageAmount);
        }
    }
}