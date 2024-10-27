using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    
    public float attackRadius = 1.5f;
    public int damage = 10;
    public LayerMask playerLayer;
    public GameObject attackObjectPrefab; // Префаб объекта атаки
    public GameObject attackSmashPrefab; // Префаб объекта атаки
    public Transform attack01SpawnPoint; // Точка, в которой будет создаваться объект атаки
    public Transform attack02SpawnPoint; // Точка, в которой будет создаваться объект атаки
    public Transform attackSmashSpawnPoint;
    public Transform particleSpawnPoint;// Точка, в которой будет создаваться объект атаки
    public float attackObjectDuration = 2.0f; // Длительность существования объекта атаки
    public int HP = 200;
    public Animator animator;
    public Slider healthBar;
    public event System.Action OnDeath;
    public GameObject hiteffect;
    public GameObject particleEffect;
    public GameObject BatAttack1;
    public GameObject BatAttack2;
    private bool hasAttacked = false; // Флаг для отслеживания того, была ли атака произведена
    private bool hasAttacked2 = false; // Флаг для отслеживания того, была ли атака произведена
    private bool hasAttackedSmash = false; // Флаг для отслеживания того, была ли атака произведена
    private bool hasAttackedBats = false; // Флаг для отслеживания того, была ли атака произведена
    //звуки
    public AudioClip attackSound;
    public AudioClip attack02Sound;
    public AudioClip attackSmashSound;
    public AudioClip attackBatsSound;
    private AudioSource audioSource;

    public GameObject EndgameBox;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        healthBar.value = HP;

        // Проверяем, проигрывается ли анимация атаки
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            hasAttacked = true; // Устанавливаем флаг, что атака началась
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack02"))
        {
            hasAttacked2 = true; // Устанавливаем флаг, что атака началась
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AttackSmash"))
        {
            hasAttackedSmash = true; // Устанавливаем флаг, что атака началась
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AttackBats"))
        {
            hasAttackedBats = true; // Устанавливаем флаг, что атака началась
        }

    }

    // Метод, вызываемый в конце анимации первой атаки
    public void AttackEnd()
    {
        if (hasAttacked)
        {
            // Создаем объект атаки в указанной точке
            GameObject attackObject = Instantiate(attackObjectPrefab, attack01SpawnPoint.position, Quaternion.identity);
            GameObject hitpoint = Instantiate(hiteffect, attack01SpawnPoint.position, Quaternion.identity);

            // Назначаем объекту атаки триггером
            attackObject.GetComponent<Collider>().isTrigger = true;

            // Уничтожаем объект атаки через указанное время
            Destroy(attackObject, attackObjectDuration);
            Destroy(hitpoint, attackObjectDuration);

            // Проверяем столкновения объекта атаки с игроком
            Collider[] hitColliders = Physics.OverlapSphere(attack01SpawnPoint.position, attackRadius, playerLayer);
            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Player"))
                {
                    AttackPlayer(col.gameObject); // Если столкнулись с игроком, наносим урон
                }
            }

            // Проигрываем звук атаки
            audioSource.PlayOneShot(attackSound);

            hasAttacked = false; // Сбрасываем флаг атаки
        }
    }

    // Метод, вызываемый в конце анимации второй атаки
    public void AttackEnd2()
    {
        if (hasAttacked2)
        {
            // Создаем объект атаки в указанной точке
            GameObject attackObject = Instantiate(attackObjectPrefab, attack02SpawnPoint.position, Quaternion.identity);
            GameObject hitpoint = Instantiate(hiteffect, attack02SpawnPoint.position, Quaternion.identity);

            // Назначаем объекту атаки триггером
            attackObject.GetComponent<Collider>().isTrigger = true;

            // Уничтожаем объект атаки через указанное время
            Destroy(attackObject, attackObjectDuration);
            Destroy(hitpoint, attackObjectDuration);

            // Проверяем столкновения объекта атаки с игроком
            Collider[] hitColliders = Physics.OverlapSphere(attack02SpawnPoint.position, attackRadius, playerLayer);
            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Player"))
                {
                    AttackPlayer(col.gameObject); // Если столкнулись с игроком, наносим урон
                }
            }

            // Проигрываем звук атаки
            audioSource.PlayOneShot(attack02Sound);

            hasAttacked2 = false; // Сбрасываем флаг атаки
        }
    }

    public void AttackSmash()
    {
        if (hasAttackedSmash)
        {
            // Создаем объект атаки в указанной точке
            GameObject attackObject = Instantiate(attackSmashPrefab, attackSmashSpawnPoint.position, Quaternion.identity);
            GameObject hitpoint = Instantiate(hiteffect, attackSmashSpawnPoint.position, Quaternion.identity);

            // Назначаем объекту атаки триггером
            attackObject.GetComponent<Collider>().isTrigger = true;

            // Уничтожаем объект атаки через указанное время
            Destroy(attackObject, attackObjectDuration);
            Destroy(hitpoint, attackObjectDuration);

            // Проверяем столкновения объекта атаки с игроком
            Collider[] hitColliders = Physics.OverlapSphere(attackSmashSpawnPoint.position, attackRadius, playerLayer);
            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Player"))
                {
                    AttackPlayer(col.gameObject); // Если столкнулись с игроком, наносим урон
                }
            }

            // Проигрываем звук атаки
            audioSource.PlayOneShot(attackSmashSound);

            hasAttackedSmash = false; // Сбрасываем флаг атаки
        }
    }

    public void AttackBats()
    {
        if (hasAttackedBats)
        {
            // Рандомно выбираем между BatAttack1 и BatAttack2
            GameObject selectedBatAttack = Random.value > 0.5f ? BatAttack1 : BatAttack2;
            selectedBatAttack.SetActive(true);
            StartCoroutine(DeactivateBats(selectedBatAttack));

            // Проигрываем звук атаки
            audioSource.PlayOneShot(attackBatsSound);

            hasAttackedBats = false; // Сбрасываем флаг атаки
        }
    }

    private IEnumerator DeactivateBats(GameObject batAttack)
    {
        yield return new WaitForSeconds(3);
        batAttack.SetActive(false);
    }

    public void BatsParticleSpawn()
    {
        if (hasAttackedBats)
        {
            // Поворачиваем объект на -90 градусов вокруг оси Y
            GameObject hitpoint = Instantiate(particleEffect, particleSpawnPoint.position, Quaternion.Euler(-90, 0, 0));
            Destroy(hitpoint, attackObjectDuration * 2);
            hasAttackedBats = false; // Сбрасываем флаг атаки
        }
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            OnDeath?.Invoke();
            animator.SetTrigger("death");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);

            EndgameBox.SetActive(true);

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