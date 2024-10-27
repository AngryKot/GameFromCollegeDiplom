using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    
    public float attackRadius = 1.5f;
    public int damage = 10;
    public LayerMask playerLayer;
    public GameObject attackObjectPrefab; // ������ ������� �����
    public GameObject attackSmashPrefab; // ������ ������� �����
    public Transform attack01SpawnPoint; // �����, � ������� ����� ����������� ������ �����
    public Transform attack02SpawnPoint; // �����, � ������� ����� ����������� ������ �����
    public Transform attackSmashSpawnPoint;
    public Transform particleSpawnPoint;// �����, � ������� ����� ����������� ������ �����
    public float attackObjectDuration = 2.0f; // ������������ ������������� ������� �����
    public int HP = 200;
    public Animator animator;
    public Slider healthBar;
    public event System.Action OnDeath;
    public GameObject hiteffect;
    public GameObject particleEffect;
    public GameObject BatAttack1;
    public GameObject BatAttack2;
    private bool hasAttacked = false; // ���� ��� ������������ ����, ���� �� ����� �����������
    private bool hasAttacked2 = false; // ���� ��� ������������ ����, ���� �� ����� �����������
    private bool hasAttackedSmash = false; // ���� ��� ������������ ����, ���� �� ����� �����������
    private bool hasAttackedBats = false; // ���� ��� ������������ ����, ���� �� ����� �����������
    //�����
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

        // ���������, ������������� �� �������� �����
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            hasAttacked = true; // ������������� ����, ��� ����� ��������
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack02"))
        {
            hasAttacked2 = true; // ������������� ����, ��� ����� ��������
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AttackSmash"))
        {
            hasAttackedSmash = true; // ������������� ����, ��� ����� ��������
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AttackBats"))
        {
            hasAttackedBats = true; // ������������� ����, ��� ����� ��������
        }

    }

    // �����, ���������� � ����� �������� ������ �����
    public void AttackEnd()
    {
        if (hasAttacked)
        {
            // ������� ������ ����� � ��������� �����
            GameObject attackObject = Instantiate(attackObjectPrefab, attack01SpawnPoint.position, Quaternion.identity);
            GameObject hitpoint = Instantiate(hiteffect, attack01SpawnPoint.position, Quaternion.identity);

            // ��������� ������� ����� ���������
            attackObject.GetComponent<Collider>().isTrigger = true;

            // ���������� ������ ����� ����� ��������� �����
            Destroy(attackObject, attackObjectDuration);
            Destroy(hitpoint, attackObjectDuration);

            // ��������� ������������ ������� ����� � �������
            Collider[] hitColliders = Physics.OverlapSphere(attack01SpawnPoint.position, attackRadius, playerLayer);
            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Player"))
                {
                    AttackPlayer(col.gameObject); // ���� ����������� � �������, ������� ����
                }
            }

            // ����������� ���� �����
            audioSource.PlayOneShot(attackSound);

            hasAttacked = false; // ���������� ���� �����
        }
    }

    // �����, ���������� � ����� �������� ������ �����
    public void AttackEnd2()
    {
        if (hasAttacked2)
        {
            // ������� ������ ����� � ��������� �����
            GameObject attackObject = Instantiate(attackObjectPrefab, attack02SpawnPoint.position, Quaternion.identity);
            GameObject hitpoint = Instantiate(hiteffect, attack02SpawnPoint.position, Quaternion.identity);

            // ��������� ������� ����� ���������
            attackObject.GetComponent<Collider>().isTrigger = true;

            // ���������� ������ ����� ����� ��������� �����
            Destroy(attackObject, attackObjectDuration);
            Destroy(hitpoint, attackObjectDuration);

            // ��������� ������������ ������� ����� � �������
            Collider[] hitColliders = Physics.OverlapSphere(attack02SpawnPoint.position, attackRadius, playerLayer);
            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Player"))
                {
                    AttackPlayer(col.gameObject); // ���� ����������� � �������, ������� ����
                }
            }

            // ����������� ���� �����
            audioSource.PlayOneShot(attack02Sound);

            hasAttacked2 = false; // ���������� ���� �����
        }
    }

    public void AttackSmash()
    {
        if (hasAttackedSmash)
        {
            // ������� ������ ����� � ��������� �����
            GameObject attackObject = Instantiate(attackSmashPrefab, attackSmashSpawnPoint.position, Quaternion.identity);
            GameObject hitpoint = Instantiate(hiteffect, attackSmashSpawnPoint.position, Quaternion.identity);

            // ��������� ������� ����� ���������
            attackObject.GetComponent<Collider>().isTrigger = true;

            // ���������� ������ ����� ����� ��������� �����
            Destroy(attackObject, attackObjectDuration);
            Destroy(hitpoint, attackObjectDuration);

            // ��������� ������������ ������� ����� � �������
            Collider[] hitColliders = Physics.OverlapSphere(attackSmashSpawnPoint.position, attackRadius, playerLayer);
            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Player"))
                {
                    AttackPlayer(col.gameObject); // ���� ����������� � �������, ������� ����
                }
            }

            // ����������� ���� �����
            audioSource.PlayOneShot(attackSmashSound);

            hasAttackedSmash = false; // ���������� ���� �����
        }
    }

    public void AttackBats()
    {
        if (hasAttackedBats)
        {
            // �������� �������� ����� BatAttack1 � BatAttack2
            GameObject selectedBatAttack = Random.value > 0.5f ? BatAttack1 : BatAttack2;
            selectedBatAttack.SetActive(true);
            StartCoroutine(DeactivateBats(selectedBatAttack));

            // ����������� ���� �����
            audioSource.PlayOneShot(attackBatsSound);

            hasAttackedBats = false; // ���������� ���� �����
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
            // ������������ ������ �� -90 �������� ������ ��� Y
            GameObject hitpoint = Instantiate(particleEffect, particleSpawnPoint.position, Quaternion.Euler(-90, 0, 0));
            Destroy(hitpoint, attackObjectDuration * 2);
            hasAttackedBats = false; // ���������� ���� �����
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