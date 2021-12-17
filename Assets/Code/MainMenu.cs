using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = true;
    }

    public void StartGame()
    {
        // SceneManager.LoadScene("Level " + GlobalVar.level.ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + GlobalVar.level);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
