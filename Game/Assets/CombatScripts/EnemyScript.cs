using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float attackRadius = 0.5f;
    public int damage = 10;
    public LayerMask playerLayer;

    public int HP = 100;
    public Animator animator;
    public Slider healthBar;
    public event System.Action OnDeath;
    public AudioSource HitSound;

    private void Update()
    {
        healthBar.value = HP;

        // ѕровер€ем, проигрываетс€ ли анимаци€ атаки
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack || Attack01 || Attack02"))
        { 
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius, playerLayer);
            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Player"))
                {
                    AttackPlayer(col.gameObject);
                }
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            HitSound.Play();
            OnDeath?.Invoke();
            animator.SetTrigger("death");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
        }
        else
        {
            HitSound.Play();
            animator.SetTrigger("damage");
        }
    }


    void AttackPlayer(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
 
    
    }


    //    void OnTriggerEnter(Collider other)
    //    {
    //        // ѕровер€ем, столкнулс€ ли коллайдер с игроком и проигрываетс€ ли анимаци€ атаки
    //        if (other.CompareTag("Player") && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
    //        {
    //            AttackPlayer(other.gameObject); // ≈сли да, вызываем метод AttackPlayer() дл€ нанесени€ урона игроку
    //        }
    //    }

    //    void AttackPlayer(GameObject player)
    //    {
    //        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
    //        if (playerHealth != null)
    //        {
    //            playerHealth.TakeDamage(damage);

    //        }
    //    }
    //}
    //void Update()
    //{
    //    // ѕровер€ем, проигрываетс€ ли анимаци€ атаки
    //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
    //    {
    //        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius, playerLayer);
    //        foreach (Collider col in hitColliders)
    //        {
    //            if (col.CompareTag("Player"))
    //            {
    //                AttackPlayer(col.gameObject);
    //            }
    //        }
    //    }
    //}
}



