using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToMenu());
    }
    IEnumerator WaitToMenu()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("Menu");
    }
}
