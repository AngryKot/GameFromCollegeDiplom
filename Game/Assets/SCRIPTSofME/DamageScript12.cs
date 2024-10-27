using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;

    // ������ �� ��������� Animator ����������

    void Start()
    {
        animator = GetComponent<Animator>(); // �������� ������ �� ��������� Animator ��� ������ �������
    }

    // ����������, ����� ��������� � ���� ����� ������������ � ������ �����������
    void OnTriggerEnter(Collider other)
    {
        // ���������, ���������� �� ��������� � ������� � ������������� �� �������� �����
        if (other.CompareTag("Player") && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            AttackPlayer(other.gameObject); // ���� ��, �������� ����� AttackPlayer() ��� ��������� ����� ������
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
