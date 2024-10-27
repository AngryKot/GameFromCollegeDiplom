using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    public GameObject TeleportEffect;
    public Material targetSkybox;

    // Позиция, куда будет телепортирован игрок
    public Transform teleportDestination;

    // Функция, вызываемая, когда игрок входит в триггер
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли объект, вошедший в триггер, игроком
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                StartCoroutine(Teleport(playerController));
            }
        }
    }

    IEnumerator Teleport(PlayerController playerController)
    {
        ShowLoadingCanvas();
        // Отключаем управление игрока перед телепортацией
        playerController.disabled = true;
        RenderSettings.skybox = targetSkybox;
        // Ждем небольшой промежуток времени
        yield return new WaitForSeconds(0.01f);

        // Телепортируем игрока к указанной позиции
        playerController.transform.position = teleportDestination.position;

        // Ждем еще немного
        yield return new WaitForSeconds(0.8f);
       
        // Включаем управление игроком после телепортации
        playerController.disabled = false;
        TeleportToTargetScene();
    }

    public string targetSceneName = "GameObject";
    public GameObject loadingCanvas;
    public float delayBeforeLoading = 1f;

    public void TeleportToTargetScene()
    {
        //// Отложенный вызов метода для отображения экрана загрузки
        //Invoke("ShowLoadingCanvas", delayBeforeLoading);

        //// Загрузить целевую сцену асинхронно
        //SceneManager.LoadSceneAsync(targetSceneName).completed += (asyncOperation) =>
        //{
        //    // Скрыть экран загрузки после завершения загрузки
            loadingCanvas.SetActive(false);
        //};
    }

    void ShowLoadingCanvas()
    {
        // Показать экран загрузки
        loadingCanvas.SetActive(true);

    }
}