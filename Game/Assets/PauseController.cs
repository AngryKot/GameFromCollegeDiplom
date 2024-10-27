using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Ссылка на Canvas меню паузы
    public GameObject optionMenuUI; // Ссылка на Canvas окна настроек
    public GameObject controlsMenuUI; // Ссылка на Canvas нового окна настроек
    public GameObject openControlsButton; // Ссылка на кнопку открытия нового меню настроек
    public GameObject closeControlsButton; // Ссылка на кнопку закрытия нового меню настроек

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
        optionMenuUI.SetActive(false); // Убедитесь, что окно настроек тоже скрыто
        controlsMenuUI.SetActive(false);

        Time.timeScale = 1f; // Возобновление времени в игре
        Cursor.lockState = CursorLockMode.Locked; // Скрыть курсор и заблокировать его в центре экрана
        Cursor.visible = false; // Сделать курсор невидимым
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        optionMenuUI.SetActive(false); // Окно настроек не активно при паузе
        controlsMenuUI.SetActive(false);
        Time.timeScale = 0f; // Замораживание времени в игре
        Cursor.lockState = CursorLockMode.None; // Разблокировать курсор
        Cursor.visible = true; // Сделать курсор видимым
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
        Application.Quit(); // Функция для выхода из игры
        // В редакторе Unity это не завершит игру. Для проверки можно использовать UnityEditor.EditorApplication.isPlaying = false;
    }
}
