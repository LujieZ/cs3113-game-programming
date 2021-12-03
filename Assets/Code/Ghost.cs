using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    Renderer renderer;
    UnityEngine.AI.NavMeshAgent _navMeshAgent;
    MazeSpawner mazeSpawner;

    // Start is called before the first frame update
    void Start()
    {
        mazeSpawner = GameObject.Find("MazeSpawner").GetComponent<MazeSpawner>();
        renderer = GetComponent<Renderer>();
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //(mazeSpawner.Rows);
        if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance){
            print("stopped");
            int x = Random.Range(0,mazeSpawner.Rows-1);
            int z = Random.Range(0,mazeSpawner.Columns-1);
            _navMeshAgent.SetDestination(new Vector3(x*8, 0, z*8));
        }
        //print(_navMeshAgent.destination);
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         print("death");
    //         SceneManager.LoadScene("Death");
    //     }
    // }
}
