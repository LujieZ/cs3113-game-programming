using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    Renderer renderer;
    UnityEngine.AI.NavMeshAgent _navMeshAgent;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player =  GameObject.FindWithTag("Player");
        //_navMeshAgent.destination = player.transform.position;
        //_navMeshAgent.destination = new Vector3(10,10,10);
    }

    // Update is called once per frame
    void Update()
    {
        //print(_navMeshAgent.enabled);
        _navMeshAgent.enabled  = !GlobalVar.Seen;

        
        if(_navMeshAgent.enabled ){
            _navMeshAgent.SetDestination(player.transform.position);
        }
        //print(_navMeshAgent.destination);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("death");
            SceneManager.LoadScene("Death");
        }
    }
}
