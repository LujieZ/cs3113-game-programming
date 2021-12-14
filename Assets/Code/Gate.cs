using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject black3;
    Animator black3_animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GlobalVar.level++;

            // Fade to black if winning the game
            if (GlobalVar.level == 4){
                black3 = GameObject.Find("Black3");
                black3_animator = black3.GetComponent<Animator>();
                black3_animator.SetTrigger("Fade");
            }
        }
    }
}
