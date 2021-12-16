using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        GlobalVar.level = 1;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else{
                Pause();
            }
        }
    }
}
