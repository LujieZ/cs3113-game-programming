using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Renderer renderer;
    public GameObject player;
    bool stopped = false;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVar.Scanned && !stopped)
        {
            StartCoroutine(Scanned());
        }
        // print(GlobalVar.Scanned);
        // renderer.enabled = GlobalVar.Scanned;
    }

    IEnumerator Scanned()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        yield return new WaitForSeconds(dist/25);
        stopped = true;
        renderer.enabled = true;
        yield return new WaitForSeconds(6);
        renderer.enabled = false;
        stopped = false;
    }
}
