using UnityEngine;

public class TransferSword : MonoBehaviour
{
    public Transform characterTransform; // Ссылка на Transform персонажа
    public GameObject sword; // Ссылка на объект меча

    public Vector3 swordOffset; // Смещение меча относительно "Hand"

    void Update()
    {
        // Обновляем позицию и поворот "Hand" к персонажу
        transform.position = characterTransform.position;
        transform.rotation = characterTransform.rotation;

        // Обновляем позицию меча относительно "Hand"
        sword.transform.localPosition = swordOffset;
    }

    void Start()
    {
        // Передаем меч противнику при запуске игры
        TransferSwordToEnemy();
    }

    void TransferSwordToEnemy()
    {
        // Устанавливаем противника родителем для "Hand"
        sword.transform.SetParent(transform);
    }
}
