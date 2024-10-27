using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // ������ �� Canvas ���� �����
    public GameObject optionMenuUI; // ������ �� Canvas ���� ��������
    public GameObject controlsMenuUI; // ������ �� Canvas ������ ���� ��������
    public GameObject openControlsButton; // ������ �� ������ �������� ������ ���� ��������
    public GameObject closeControlsButton; // ������ �� ������ �������� ������ ���� ��������

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        openControlsButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(false); // ���������, ��� ���� �������� ���� ������
        controlsMenuUI.SetActive(false);

        Time.timeScale = 1f; // ������������� ������� � ����
        Cursor.lockState = CursorLockMode.Locked; // ������ ������ � ������������� ��� � ������ ������
        Cursor.visible = false; // ������� ������ ���������
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        optionMenuUI.SetActive(false); // ���� �������� �� ������� ��� �����
        controlsMenuUI.SetActive(false);
        Time.timeScale = 0f; // ������������� ������� � ����
        Cursor.lockState = CursorLockMode.None; // �������������� ������
        Cursor.visible = true; // ������� ������ �������
        isPaused = true;
    }

    public void OpenOptions()
    {
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(true);

    }

    public void CloseOptions()
    {
        
        optionMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void OpenControls()
    {
        controlsMenuUI.SetActive(true);
        openControlsButton.SetActive(false);
    }
    public void CloseControls()
    {
        controlsMenuUI.SetActive(false);
        openControlsButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit(); // ������� ��� ������ �� ����
        // � ��������� Unity ��� �� �������� ����. ��� �������� ����� ������������ UnityEditor.EditorApplication.isPlaying = false;
    }
}
