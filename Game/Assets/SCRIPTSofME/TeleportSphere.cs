using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    public GameObject TeleportEffect;
    public Material targetSkybox;

    // �������, ���� ����� �������������� �����
    public Transform teleportDestination;

    // �������, ����������, ����� ����� ������ � �������
    private void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������, �������� � �������, �������
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
        // ��������� ���������� ������ ����� �������������
        playerController.disabled = true;
        RenderSettings.skybox = targetSkybox;
        // ���� ��������� ���������� �������
        yield return new WaitForSeconds(0.01f);

        // ������������� ������ � ��������� �������
        playerController.transform.position = teleportDestination.position;

        // ���� ��� �������
        yield return new WaitForSeconds(0.8f);
       
        // �������� ���������� ������� ����� ������������
        playerController.disabled = false;
        TeleportToTargetScene();
    }

    public string targetSceneName = "GameObject";
    public GameObject loadingCanvas;
    public float delayBeforeLoading = 1f;

    public void TeleportToTargetScene()
    {
        //// ���������� ����� ������ ��� ����������� ������ ��������
        //Invoke("ShowLoadingCanvas", delayBeforeLoading);

        //// ��������� ������� ����� ����������
        //SceneManager.LoadSceneAsync(targetSceneName).completed += (asyncOperation) =>
        //{
        //    // ������ ����� �������� ����� ���������� ��������
            loadingCanvas.SetActive(false);
        //};
    }

    void ShowLoadingCanvas()
    {
        // �������� ����� ��������
        loadingCanvas.SetActive(true);

    }
}