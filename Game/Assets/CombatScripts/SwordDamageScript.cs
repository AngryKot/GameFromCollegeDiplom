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
//    //        // ���������, ������������� �� ��� ������ � ������


//    //            // �������� ����� TakeDamage � ���������� EnemyScript �� ������� �����
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
        // ���������, ���� �� ������ ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // ���� ������ ���� ���� ������, ��������� �������� ����
            canDamage = true;
            // ��������� ��������, ����� ��������� ����������� ��������� ����� ����� �������
            StartCoroutine(DisableDamage());
        }
    }

    private IEnumerator DisableDamage()
    {
        // ���� ���� �������
        yield return new WaitForSeconds(0.5f);
        // ����� ���������� ������� ��������� ����������� ��������� �����
        canDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ������������� �� ��� ������ � ������
        if (other.CompareTag("Enemy") && canDamage)
        {
            // ���� ��������� �������� ����, �������� ����� TakeDamage � ���������� EnemyScript �� ������� �����
            other.GetComponent
              <EnemyScript>().TakeDamage(damageAmount);
        }
        if (other.CompareTag("Boss") && canDamage)
        {
            // ���� ��������� �������� ����, �������� ����� TakeDamage � ���������� EnemyScript �� ������� �����
            other.GetComponent
              <BossScript>().TakeDamage(damageAmount);
        }
    }
}