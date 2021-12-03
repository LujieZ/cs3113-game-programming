using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        _animator.SetTrigger("Fade");
    }
}
