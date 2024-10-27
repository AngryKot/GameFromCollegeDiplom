using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator; // ������ �� ��������� Animator


    private const string key_isRun = "IsRun";
    private const string key_isAttack01 = "IsAttack01";
    private const string key_isAttack02 = "IsAttack02";
    private const string key_isJump = "IsJump";
    private const string key_isDamage = "IsDamage";
    private const string key_isDead = "IsDead";




    public int maxHealth = 100;     // ������������ �������� ���������
    public int currentHealth;       // ������� �������� ���������
    public TextMeshProUGUI healthText;        // ������ �� ��������� ������� ��� ����������� ��������
         

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;  // ��������� ���������� ��������
        // ��������� ����������� �������� �� ������
        UpdateHealthUI();
    }

    // ����� ��� ��������� �����
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;  // ��������� ������� �������� �� ���������� �����

        // ���������, �� ����� �� �������� ���� ����
        if (currentHealth <= 0)
        {
            Die();  // ���� ��, �������� ����� Die()
        }
        else
        {
            // ���� ������� �������� ������ ����, ����������� �������� DamageTaken
            
            
                animator.SetBool("IsDamage", true);
            
        }

        // ��������� ����������� �������� �� ������
        UpdateHealthUI();
    }

    // ����� ��� �������������� ��������
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;  // ����������� ������� �������� �� ���������� ���������

        // ���������, �� ��������� �� ������� �������� ������������ ��������
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;  // ���� ��, ������������ ��� ������������ ���������
        }

        // ��������� ����������� �������� �� ������
        UpdateHealthUI();
    }

    // ����� ��� ���������� ����������� �������� �� ������
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "" + currentHealth;// ��������� ��������� ������� � ������� ���������
        }
    }

    // ����� ����������, ����� �������� ��������� ������ �� ����
    void Die()
    {
        animator.SetBool("IsDead", true);

        new WaitForSeconds(2f);
        PlayerController playerController = GetComponent<PlayerController>();
        StartCoroutine(Teleport(playerController));
        // �������������� �������� ��� ������ ���������, ��������, �������� ����� ��� �������� ������
        Debug.Log("Player died!");  // ������ ��� �������, ����� �������� �� ���� ������
    }

    IEnumerator Teleport(PlayerController playerController)
    {
        playerController.disabled = true;
        yield return new WaitForSeconds(2f);
        ShowGameEndCanvas();
        // ��������� ���������� ������ ����� �������������
        
        yield return new WaitForSeconds(1000000f);
    }

    public GameObject ShowCanvas;
    public float delayBeforeLoading = 1f;

    void ShowGameEndCanvas()
    {
        // �������� ����� ��������
        ShowCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }
}
