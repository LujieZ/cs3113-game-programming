using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToMenu());
    }
    IEnumerator WaitToMenu()
    {
        yield return new WaitForSeconds(39.5f);
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
