using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FadeBlackT : MonoBehaviour
{
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(FadeToBlack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeToBlack()
    {
        yield return new WaitForSeconds(0.1f);
        // If in Death Scene
        if (SceneManager.GetActiveScene().name == "Death"){
            _animator.SetTrigger("Fade");
        }
    }
}
