using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator; // Ссылка на компонент Animator


    private const string key_isRun = "IsRun";
    private const string key_isAttack01 = "IsAttack01";
    private const string key_isAttack02 = "IsAttack02";
    private const string key_isJump = "IsJump";
    private const string key_isDamage = "IsDamage";
    private const string key_isDead = "IsDead";




    public int maxHealth = 100;     // Максимальное здоровье персонажа
    public int currentHealth;       // Текущее здоровье персонажа
    public TextMeshProUGUI healthText;        // Ссылка на текстовый элемент для отображения здоровья
         

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;  // Установка начального здоровья
        // Обновляем отображение здоровья на экране
        UpdateHealthUI();
    }

    // Метод для получения урона
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;  // Уменьшаем текущее здоровье на количество урона

        // Проверяем, не упала ли здоровье ниже нуля
        if (currentHealth <= 0)
        {
            Die();  // Если да, вызываем метод Die()
        }
        else
        {
            // Если уровень здоровья больше нуля, проигрываем анимацию DamageTaken
            
            
                animator.SetBool("IsDamage", true);
            
        }

        // Обновляем отображение здоровья на экране
        UpdateHealthUI();
    }

    // Метод для восстановления здоровья
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;  // Увеличиваем текущее здоровье на количество исцеления

        // Проверяем, не превышает ли текущее здоровье максимальное значение
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;  // Если да, ограничиваем его максимальным значением
        }

        // Обновляем отображение здоровья на экране
        UpdateHealthUI();
    }

    // Метод для обновления отображения здоровья на экране
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "" + currentHealth;// Обновляем текстовый элемент с текущим здоровьем
        }
    }

    // Метод вызывается, когда здоровье персонажа падает до нуля
    void Die()
    {
        animator.SetBool("IsDead", true);

        new WaitForSeconds(2f);
        PlayerController playerController = GetComponent<PlayerController>();
        StartCoroutine(Teleport(playerController));
        // Дополнительные действия при смерти персонажа, например, загрузка сцены или анимация смерти
        Debug.Log("Player died!");  // Просто для примера, можно заменить на свою логику
    }

    IEnumerator Teleport(PlayerController playerController)
    {
        playerController.disabled = true;
        yield return new WaitForSeconds(2f);
        ShowGameEndCanvas();
        // Отключаем управление игрока перед телепортацией
        
        yield return new WaitForSeconds(1000000f);
    }

    public GameObject ShowCanvas;
    public float delayBeforeLoading = 1f;

    void ShowGameEndCanvas()
    {
        // Показать экран загрузки
        ShowCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }
}
