using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{
    public GameObject pacman1;
    public GameObject pacman2;
    public GameObject pacman3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Setup());
        pacman1.SetActive(false);
        pacman2.SetActive(false);
        pacman3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Setup()
    {
        yield return new WaitForSeconds(12f);
        pacman1.SetActive(true);
        yield return new WaitForSeconds(6f);
        pacman2.SetActive(true);
        yield return new WaitForSeconds(3.7f);
        pacman2.SetActive(false);
        pacman3.SetActive(true);

    }
}
