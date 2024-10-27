using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float startVolume = 0.1f; // Громкость звука при запуске
    public void LoadLevel()
    {
        SceneManager.LoadScene("Save15Sounds");// в кавычках название сцены на которую осуществляется переход
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
}