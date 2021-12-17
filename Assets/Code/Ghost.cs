using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class Ghost : MonoBehaviour
{
    Renderer renderer;
    UnityEngine.AI.NavMeshAgent _navMeshAgent;
    MazeSpawner mazeSpawner;
    public FirstPersonController fpc;
    public GameObject player;
    public AudioSource audioSource;

    bool stopped = false;

    // Start is called before the first frame update
    void Start()
    {
        mazeSpawner = GameObject.Find("MazeSpawner").GetComponent<MazeSpawner>();
        renderer = GetComponent<Renderer>();
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        fpc = GameObject.FindWithTag("Player").GetComponent<FirstPersonController>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVar.Scanned && !stopped)
        {
            StartCoroutine(Stopped());
        }
        //(mazeSpawner.Rows);
        if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance){
            int x = Random.Range(0,mazeSpawner.Rows-1);
            int z = Random.Range(0,mazeSpawner.Columns-1);
            _navMeshAgent.SetDestination(new Vector3(x*8, 0, z*8));
        }
        //print(_navMeshAgent.destination);
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GlobalVar.Blackout)
        {
            if(gameObject.tag == "Ghost1")
            {
                audioSource.Play();
                GlobalVar.Blackout = true;
                yield return new WaitForSeconds(3);
                GlobalVar.Blackout = false;
            }

            else if(gameObject.tag == "Ghost2")
            {
                audioSource.Play();
                fpc.RotationSpeed = 0;
                fpc.MoveSpeed = 0;
                yield return new WaitForSeconds(3);
                fpc.RotationSpeed = GlobalVar.sensitivity;
                fpc.MoveSpeed = 4;
            }
        }
    }

    IEnumerator Stopped()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        yield return new WaitForSeconds(dist/25);
        stopped = true;
        _navMeshAgent.isStopped= true;
        yield return new WaitForSeconds(6);
        _navMeshAgent.isStopped = false;
        stopped = false;
    }
}
