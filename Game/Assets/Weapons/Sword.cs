using UnityEngine;

public class TransferSword : MonoBehaviour
{
    public Transform characterTransform; // ������ �� Transform ���������
    public GameObject sword; // ������ �� ������ ����

    public Vector3 swordOffset; // �������� ���� ������������ "Hand"

    void Update()
    {
        // ��������� ������� � ������� "Hand" � ���������
        transform.position = characterTransform.position;
        transform.rotation = characterTransform.rotation;

        // ��������� ������� ���� ������������ "Hand"
        sword.transform.localPosition = swordOffset;
    }

    void Start()
    {
        // �������� ��� ���������� ��� ������� ����
        TransferSwordToEnemy();
    }

    void TransferSwordToEnemy()
    {
        // ������������� ���������� ��������� ��� "Hand"
        sword.transform.SetParent(transform);
    }
}
