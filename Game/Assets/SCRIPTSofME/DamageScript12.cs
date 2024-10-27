using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;

    // Ссылка на компонент Animator противника

    void Start()
    {
        animator = GetComponent<Animator>(); // Получаем ссылку на компонент Animator при старте скрипта
    }

    // Вызывается, когда коллайдер в руке врага сталкивается с другим коллайдером
    void OnTriggerEnter(Collider other)
    {
        // Проверяем, столкнулся ли коллайдер с игроком и проигрывается ли анимация атаки
        if (other.CompareTag("Player") && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            AttackPlayer(other.gameObject); // Если да, вызываем метод AttackPlayer() для нанесения урона игроку
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
}
