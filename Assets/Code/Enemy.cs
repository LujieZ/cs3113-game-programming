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
        _navMeshAgent.enabled  = !GlobalVar.Seen || GlobalVar.Dark;
        if(GlobalVar.Seen && GlobalVar.Dark || RemainingDistance(_navMeshAgent.path.corners)>30){
            _navMeshAgent.speed = 30;
        }
        else{
            _navMeshAgent.speed = 6;
        }

        
        if(_navMeshAgent.enabled ){
            _navMeshAgent.SetDestination(player.transform.position);
        }
        //print(_navMeshAgent.destination);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Death");
        }
    }

    float RemainingDistance(Vector3[] points)
    {
        if (points.Length < 2) return 0;
        float distance = 0;
        for (int i = 0; i < points.Length - 1; i++)
            distance += Vector3.Distance(points[i], points[i + 1]);
        return distance;
    }
}
